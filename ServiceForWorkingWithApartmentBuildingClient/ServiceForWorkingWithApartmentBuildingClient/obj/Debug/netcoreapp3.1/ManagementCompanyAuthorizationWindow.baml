   M S B A M L   `   `   `  ����g  cServiceForWorkingWithApartmentBuildingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:ServiceForWorkingWithApartmentBuildingClient,ServiceForWorkingWithApartmentBuildingClient  5   	   W    QServiceForWorkingWithApartmentBuildingClient.ManagementCompanyAuthorizationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:ServiceForWorkingWithApartmentBuildingClient     5   	     � Title$*  $ManagementCompanyAuthorizationWindow��5   	   $	��590��66   $	��800��6C    � WindowStartupLocation$ CenterOwner=�5	   	   ���#837FA2.��5      �� .+�5   
   �� .@�5      �� $	��100��6   $��Вход��5   6   ��5      �� 5      ���#837FA2$	��550��66   .+�5      �� -   5         ��Name$ lblName��5       $��Center=�61   $��20(�6N   $��0,70,0,0q�6\   
�������.��6�   Добрый день6�   �� 5       �� Orientation$ 
Horizontal=�6%   $��0,30,0,0q�6>   $��Center=�6P   .+�5      �� 
�������$��14(�6;   $	��110��6I   .��6V   Название:6a   �� 5      -   5         ��Name$ tbName��5   &   $	��280��66   $��23��6B   6i   5      �� 5      $ 
Horizontal=�6%   $��0,20,0,0q�6>   $��Center=�6P   .+�5      �� 
�������$��14(�6;   $	��110��6I   .��6U   Пароль:6^   G� 5      -   5         G�Name$ psbPass��5   *   $	��280��6;   $��23��6G    G� 	MaxLength$ 64��6m   6~   5      �� 5      -   5        $ lblErrorAuthentification��5       $��	125,0,0,0q�6B   $��25��6U   
�������$��10(�6{   6�   �� 5      -   5         ��Name$ btnAuthentification��5   !   $��60��6>   $��25��6I   $��0,15,0,0q�6U   .��6�   Ок6�   5      5      �� 5      $	��100��6   $��Регистрация��5    =   ��5!      �� 5"      ���#837FA2$	��550��66   .+�5#      �� $��	0,20,0,20q�6    
�������$��Center=�6J   $��16(�6g   .��6u   Регистрация6�   �� 5%      $ 
Horizontal=�6%   $
|�True��6?   $
��Left=�6P   .+�5&      �� -   5         ��Name$ 	imgAvatar��5&   $   $��50��67   $��50��6B   $
��Fill=�6N   $��	230,0,0,0q�6]   6s   �� 5'      -   5        $ btnDownloadAvatar��5'   %   $	��130��6@   $��25��6L   $��	110,0,0,0q�6X   .��6�   Загрузить фото6�   5(      �� 5)      $ 
Horizontal=�6%   $��Center=�6>   $
|�True��6[   $��0,20,0,0q�6l   .+�5*      �� $	��140��6$   $��0,0,10,0q�60   
�������$��14(�6Y   .��6g   Название:6r   �� 5+      -   5        $ tbRegistrationName��5+   &   $	��280��6B   $��23��6s   6�   5,      �� 5-      $ 
Horizontal=�6%   $��Center=�6>   $
|�True��6[   $��0,20,0,0q�6l   .+�5.      �� $	��140��6$   $��0,0,10,0q�60   
�������$��14(�6Y   .��6g   Пароль:6p   G� 5/      -	   5        $ psbRegistrationPass��5/   *   $	��280��6G   $��23��6S   $ 64��6�   6�   50      �� 51      $ 
Horizontal=�6%   $��Center=�6>   $
|�True��6[   $��0,20,0,0q�6l   .+�52      �� $	��140��6$   $��0,0,10,0q�60   
�������$��14(�6Y   .��6g   " Повторите пароль:6z   G� 53      -
   5        $ psbRegistrationRepeatPass��53   *   $	��280��6M   $��23��6Y   $ 64��6�   6�   54      �� 55      $ 
Horizontal=�6%   $��Center=�6>   $
|�True��6[   $��0,20,0,0q�6l   .+�56      �� $	��140��6$   $��0,0,10,0q�60   
�������$��14(�6Y   .��6g   Информация:6t   �� 57      -   5        $ tbRegistrationInfo��57   &   $	��280��6B   	 �� 	MaxLength$
	 1024��6N   $��80��58   &   
 �� TextWrapping$

 Wrap=�62    �� TextAlignment$ Justify=�6F   $
��Auto=�6^   6�   59      �� 5:      -   5        $ btnRegister��5:   !   $��60��66   $��25��6A   $��0,25,0,0q�6M   .��6z   Ок6~   �� 5;      -   5        $ lbErrorMessage��5;       $��0,15,0,0q�68   
�������$��Center=�6a   5<      5>      5?      5A      5B      