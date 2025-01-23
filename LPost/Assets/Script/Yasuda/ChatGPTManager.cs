using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ChatGPTManager : MonoBehaviour
{
    [Header("�v���C���[�����ꂽ�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI inputText;
    [Header("AI�̓���")]
    [SerializeField] private TextMeshProUGUI aiText;
    [Header("InputField")]
    [SerializeField] private TMP_InputField inputField;

    //��������_���̊l�������肢���܂��B
    public int Point { get; set; }

    private string aiAnswer;
    private int positivePoint;

    private bool inputQuestion;
    private bool ableQuestion;
    private bool firstQuestion;
    private bool calculation;
    #region �K�v�ȃN���X�̒�`�Ȃ�
    [System.Serializable]
    public class MessageModel
    {
        public string role;
        public string content;
    }

    [System.Serializable]
    public class CompletionRequestModel
    {
        public string model;
        public List<MessageModel> messages;
    }

    [System.Serializable]
    public class ChatGPTResponseModel
    {
        public string id;
        public string @object;
        public int created;
        public Choice[] choices;
        public Usage usage;

        [System.Serializable]
        public class Choice
        {
            public int index;
            public MessageModel message;
            public string finish_reason;
        }

        [System.Serializable]
        public class Usage
        {
            public int prompt_tokens;
            public int completion_tokens;
            public int total_tokens;
        }
    }
    #endregion

    private MessageModel assistantModel = new MessageModel
    {
        role = "system",
        content = ""
    };

    private readonly string apiKey = "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";
    private List<MessageModel> communicationHistory = new();

    void Start()
    {
        Set();
        communicationHistory.Add(assistantModel);

        MessageSubmit("���Ȃ��͍����琔�������b���Ȃ��ł��������B\n" +
            "����ȍ~���镶�͂��ȉ��̏��Ԃœ_�������Ă��̒l�����Ԃ��Ă��������B\n" +
            "��ԖځA�|�W�e�B�u�ȈӖ��̂���i���̐����o���Ă��������B\n" +
            "��ԖځA���x��\�������̐����o���Ă�����1�𑫂��Ă��������B\n" +
            "��ԖڂƓ�Ԗڂɏo���������|���Z���������̐������_���ł��B\n" +
            "�_���̐����������������B");
    }

    private float time = 0f;
    void Update()
    {
        if (inputQuestion)
        {
            time += Time.deltaTime;

            if (time > 1.0f)
            {
                AssignmentPoint();
                inputQuestion = false;
                calculation = true;
            }
        }

        if (calculation)
        {
            CalculationPoint();
            Debug.Log(Point);
            calculation = false;
        }
    }

    private void Set()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        inputQuestion = false;
        ableQuestion = true;
        firstQuestion = false;
        calculation = false;
    }

    public void CheckPositive()
    {
        string inputtext = inputField.text;
        if (inputtext != null)
        {
            if (!inputQuestion)
            {
                MessageSubmit(inputtext);
                //inputText.text = "";
                //inputField.text = "";
                inputQuestion = true;
            }
        }
    }

    //�������琔���ɕϊ�
    private void AssignmentPoint()
    {
        positivePoint = int.Parse(aiAnswer);
        Debug.Log(positivePoint);
    }

    private void CalculationPoint()
    {
        if (positivePoint <= 0)
        {
            Point = 15;
        }
        else if (positivePoint > 0 && positivePoint <= 5)
        {
            Point = 20;
        }
        else if (positivePoint > 5 && positivePoint <= 10)
        {
            Point = 25;
        }
        else if (positivePoint > 10)
        {
            Point = 30;
        }

    }

    private void Message(string newMessage, Action<MessageModel> onResult)
    {
        Debug.Log($"���M���b�Z�[�W: {newMessage}");
        communicationHistory.Add(new MessageModel
        {
            role = "user",
            content = newMessage
        });

        var apiUrl = "https://api.openai.com/v1/chat/completions";
        var jsonOptions = JsonUtility.ToJson(new CompletionRequestModel
        {
            model = "gpt-3.5-turbo",
            messages = communicationHistory
        }, true);

        StartCoroutine(SendRequest(apiUrl, jsonOptions, onResult));
    }

    private IEnumerator SendRequest(string url, string jsonData, Action<MessageModel> onResult)
    {
        // �����I��UnityWebRequest���쐬
        UnityWebRequest request = new UnityWebRequest(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData)),
            downloadHandler = new DownloadHandlerBuffer()
        };

        // �w�b�_�[��ݒ�
        request.SetRequestHeader("Authorization", $"Bearer {apiKey}");
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("X-Slack-No-Retry", "1");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"�G���[: {request.error}");
            yield break;
        }

        string responseString = request.downloadHandler.text;
        try
        {
            ChatGPTResponseModel responseObject = JsonUtility.FromJson<ChatGPTResponseModel>(responseString);
            MessageModel assistantMessage = responseObject.choices[0].message;
            communicationHistory.Add(assistantMessage);

            Debug.Log($"AI�̉���: {assistantMessage.content}");
            onResult?.Invoke(assistantMessage);
        }
        catch (Exception ex)
        {
            Debug.LogError($"���X�|���X�̉�͒��ɃG���[���������܂���: {ex.Message}");
        }
        finally
        {
            request.Dispose(); // �����I�Ƀ��\�[�X�����
        }
    }

    public void MessageSubmit(string sendMessage)
    {
        Message(sendMessage, result =>
        {
            Debug.Log($"��M���b�Z�[�W: {result.content}");
            //aiText.text = $"GPT:{result.content}";

            aiAnswer = $"{result.content}";
        });
    }
}

