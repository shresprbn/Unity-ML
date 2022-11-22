using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;

public class form : MonoBehaviour
{
    int age;
    string sex;
    string chest_pain_type;
    int resting_bp;
    int cholesterol;
    int fasting_bs;
    string resting_ecg;
    int max_hr;
    string exercise_angina;
    float old_peak;
    string st_slope;

    string test;
    private TMP_InputField temo;
    private TMP_Dropdown temp;
    List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

    string textInput(TMP_InputField field){
        test = temo.text;
        return test;
    }

    string dropdownInput(TMP_Dropdown field){
        test = field.options[field.value].text;
        return test;
    }

    public void ageInput()
    {
        temo = GameObject.Find("age").GetComponent<TMP_InputField>();
        textInput(temo);
        int.TryParse(test, out age);
        Debug.Log(age);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("age", data));
    }

    public void sexInput(){
        temp = GameObject.Find("sex").GetComponent<TMP_Dropdown>();
        dropdownInput(temp);
        sex = test;
        Debug.Log(sex);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("sex", data));
    }

    public void chest_pain_typeInput(){
        temp = GameObject.Find("chest_pain_type").GetComponent<TMP_Dropdown>();
        dropdownInput(temp);
        chest_pain_type = test;
        Debug.Log(chest_pain_type);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("chest_pain_type", data));
    }

    public void resting_bpInput(){
        temo = GameObject.Find("resting_bp").GetComponent<TMP_InputField>();
        textInput(temo);
        int.TryParse(test, out resting_bp);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("resting_bp", data));
    }

    public void blood_cholesterolInput(){
        temo = GameObject.Find("blood_cholesterol").GetComponent<TMP_InputField>();
        textInput(temo);
        int.TryParse(test, out cholesterol);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("cholesterol",data));
    }

    public void fasting_bsInput(){
        temp = GameObject.Find("fasting_bs").GetComponent<TMP_Dropdown>();
        dropdownInput(temp);
        int.TryParse(test, out fasting_bs);
        Debug.Log(fasting_bs);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("fasting_bs", data));   
    }

    public void resting_ecgInput(){
        temp = GameObject.Find("resting_ecg").GetComponent<TMP_Dropdown>();
        dropdownInput(temp);
        resting_ecg = test;
        Debug.Log(resting_ecg);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("resting_ecg", data));
        
    }

    public void max_hrInput(){
        temo = GameObject.Find("max_hr").GetComponent<TMP_InputField>();
        textInput(temo);
        int.TryParse(test, out max_hr);
        Debug.Log(max_hr);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("max_hr", data));
    }

    public void exercise_anginaInput(){
        temp = GameObject.Find("exercise_angina").GetComponent<TMP_Dropdown>();
        dropdownInput(temp);
        exercise_angina = test;
        Debug.Log(exercise_angina);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("exercise_angina", data));
    }

    public void old_peakInput(){
        temo = GameObject.Find("old_peak").GetComponent<TMP_InputField>();
        textInput(temo);
        float.TryParse(test, out old_peak);
        Debug.Log(old_peak);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("old_peak", data));
    }

    public void st_slopeInput(){
        temp = GameObject.Find("st_slope").GetComponent<TMP_Dropdown>();
        dropdownInput(temp);
        st_slope = test;
        Debug.Log(st_slope);
        byte[] data = Encoding.ASCII.GetBytes(test);
        formData.Add(new MultipartFormDataSection("st_slope", data));
    }

    public void submitButton(){
        StartCoroutine(Upload());
        
    }

    public void backButton(){
        SceneManager.LoadScene("mainForm");
    }

    public void loadNextPage(string tex){
        int check;
        int.TryParse(tex, out check);
        if(check == 1)
        SceneManager.LoadScene("yes");
        else 
        SceneManager.LoadScene("no");
    }

    IEnumerator Upload(){
        
        Debug.Log(formData);
        UnityWebRequest www = UnityWebRequest.Post("https://unity-flask.herokuapp.com/find", formData);
        yield return www.SendWebRequest();
        var text = www.downloadHandler.text;
        Debug.Log(text);

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        loadNextPage(text);
    }
    
}
