   M S B A M L   `   `   `  ����g  cServiceForWorkingWithApartmentBuildingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:ServiceForWorkingWithApartmentBuildingClient,ServiceForWorkingWithApartmentBuildingClient  5   	   K    EServiceForWorkingWithApartmentBuildingClient.RegistrationTenantWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:ServiceForWorkingWithApartmentBuildingClient     5   	     � Title$  RegistrationTenantWindow��5   	   $	��550��6*   $	��600��67   ���#2b8f8f � WindowStartupLocation$ CenterOwner=�6X   .��5	      �� .+�5
   
   �� $��	0,10,0,10q�6   
�������$��Center=�6:   $��16(�6W   .��6e   Регистрация6r   �� 5   
    �� Orientation$ 
Horizontal=�6   $
|�True��6/   .+�5      �� -   5         ��Name$ 	imgAvatar��5      $��40��6'   $��40��62   $
��Fill=�6>   $��	140,0,0,0q�6M   6b   �� 5      -   5         ��Name$ btnDownloadAvatar��5      $	��130��60   $��25��6<   $��	125,0,0,0q�6H   .��6{   Загрузить фото6�   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   	Имя:6O   �� 5      -   5         ��Name$ tbName��5      $	��200��6&   6M   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   Фамилия:6S   �� 5      -   5        $ 	tbSurname��5      $	��200��6)   6T   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   Дата рождения:6Y   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ tbBirthDate��5      $	��200��6.   6<   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   Адрес:6Q   �� 5      -   5         ��Name$ 
cmbAddress��5      $	��200��6+   69   5      �� 5    
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5!      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   Подъезд:6S   �� 5"      -   5        $ tbEntranceNumber��5"      $	��200��60   6a   5#      �� 5$   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5%      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   Квартира:6T   �� 5&      -   5        $ tbFlatNumber��5&      $	��200��6,   6Y   5'      �� 5(   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5)      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   Пароль:6R   G� 5*      -	   5         G�Name$ psbNewPassword��5*      $	��200��62   	 G� 	MaxLength$	 64��6>   6p   5+      �� 5,   
   $ 
Horizontal=�6   $��Center=�6.   $
|�True��6K   $��0,10,0,0q�6\   .+�5-      �� $	��120��6   $��0,0,10,0q�6    
�������.��6I   " Повторите пароль:6\   G� 5.      -
   5        $ psbRepeatPassword��5.      $	��200��65   $	 10��6A   6v   5/      �� 50   
   -   5        $ btnSaveNewTenant��50      $��0,25,0,0q�6+   $��50��6=   
 J� RenderTransformOrigin$
 	0.5,0.508&�6g   .��6�   Ок6�   �� 51   
   -   5         ��Name$ lbErrorMessage��51      $��0,15,0,0q�6(   
�������$��Center=�6Q   52      53      