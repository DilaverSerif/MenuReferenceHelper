using MenuHelper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Example
{
    public class Example : MonoBehaviour
    {
        private Button button1;
        private Button button2;
    
        private Image image1;
        private Image image2;
    
        private TextMeshProUGUI text1;
        private TextMeshProUGUI text2;

        private void Awake()
        {
            button1 = EHelperMenu.HelperButton.GetMenuItem<Button>();
            button2 = EHelperMenu2.HelperButton2.GetMenuItem<Button>();
        
            image1 = EHelperMenu.HelperImage.GetMenuItem<Image>();
            image2 = EHelperMenu2.HelperImage2.GetMenuItem<Image>();
        
            text1 = EHelperMenu.HelperText.GetMenuItem<TextMeshProUGUI>();
            text2 = EHelperMenu2.HelperText2.GetMenuItem<TextMeshProUGUI>();

        }

        private void Start()
        {
            button1.onClick.AddListener(() =>
            {
                text1.text = "Button 1 Clicked";
                image1.color = Color.red;
            });
        
            button2.onClick.AddListener(() =>
            {
                text2.text = "Button 2 Clicked";
                image2.color = Color.blue;
            });
        }
    }
}
