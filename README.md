##### What does it do?
ui elements keep references in enum type for easier access.

### Example Usage
1. First assign a MenuData script to any transform.<br>
![](https://imgur.com/325btQN.png)
2. Change the tag of any canvas to MainCanvas.<br>
![](https://i.imgur.com/KxboCxL.png)
3. Create a Helper Menu (*UI>Helper Menu*) **its parent must be maincanvas**<br>
![](https://i.imgur.com/guSVuof.png)
4. Now just create helperbutton  **its parent must be helpermenu**<br>
![](https://i.imgur.com/hSdZ38s.png)
5. now we can create enums (Tools > Menu System > Get Menu Items)<br>
![](https://i.imgur.com/nDg14NJ.png)
6. We can now reference access with enums<br>

```csharp
public class Example : MonoBehaviour
    {   //EXAMPLE CODE
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
```

##### If you want to access the menus, use this method
```csharp
    private void Awake()
        {
            var getMenu = EMenuContainers.HelperMenu.GetMenu<MenuContainer>();
            //Remember menus are must have a Menu Container component
        }
```


