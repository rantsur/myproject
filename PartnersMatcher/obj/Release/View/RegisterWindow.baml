   M S B A M L   `   `   `  ���� J  FPartnersMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PartnersMatcher.ViewPartnersMatcher.View  )    #PartnersMatcher.View.RegisterWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:PartnersMatcher.View       � Title$  RegisterWindow��$	��450��$	��910��.���  � RowDefinitions �� $
��108* ��� $
��311* �.+��� -    ��Name$ 	textBlock��$
��Left=�$��56��$��738,-5,-2,0q�$
��Wrap=�$	��Top=�$	��156��$��40(���  �� FlowDirection$ RightToLeft=�$�
הרשמה���� -   $ 
textBlock1��$
��Left=�$
��Wrap=�$	��Top=�$��
786,66,0,0q�$��18(�$	��100���� $ RightToLeft=�$�שם משתמש���� -    ��Name$ tb_username��$
��Left=�$��25��$��
657,92,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��229��$��2��-  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=��� -   $ textBlock1_Copy��$
��Left=�$
��Wrap=�$	��Top=�$��
832,14,0,0q�$��18(�$��1���� $ RightToLeft=�$�
סיסמה��G� -    G�Name$ tb_password��$
��Left=�$��25��$��
657,38,0,0q�$	��Top=�$	��229��$��1���� -   $ textBlock1_Copy1��$
��Left=�$
��Wrap=�$	��Top=�$��
786,63,0,0q�$��18(�$��98��$��1���� $ RightToLeft=�$�ווידוא סיסמה��G� -   $ tb_verPassword��$
��Left=�$��25��$��
657,89,0,0q�$	��Top=�$	��229��$��1���� -   $ textBlock1_Copy2��$
��Left=�$
��Wrap=�$	��Top=�$��813,114,0,0q�$��18(�$��71��$��1���� $ RightToLeft=�$�שם פרטי���� -	   $ tb_fname��$
��Left=�$��25��$��657,141,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229��$��1���� -
   $ textBlock1_Copy3��$
��Left=�$
��Wrap=�$	��Top=�$��790,171,0,0q�$��18(�$��99��$��1���� $ RightToLeft=�.��� $�ש���� $�ם משפחה���� -   $ tb_lname��$
��Left=�$��25��$��657,195,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229��$��1���� -   $ textBlock1_Copy4��$
��Left=�$
��Wrap=�$	��Top=�$��865,221,0,0q�$��18(�$��1���� $ RightToLeft=�$�מין���� -    ��Name$ 	lb_gender��$
��Left=�$��26��$��658,245,0,0q�$	��Top=�$	��228��$��1���� -   $ textBlock1_Copy5��$
��Left=�$
��Wrap=�$	��Top=�$��
399,65,0,0q�$��18(�$	��175���� $ RightToLeft=�$*�$כתובת דואר אלקטרוני���� -   $ tb_email��$
��Left=�$��25��$��
340,92,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229��$��2���� -   $	 lll��$
��Left=�$
��Wrap=�$	��Top=�$��	458,9,0,0q�$��18(�$	��111��$��1���� $ RightToLeft=�$�כתובת מגורים���� -   $ textBlock1_Copy7��$
��Left=�$
��Wrap=�$	��Top=�$��
536,38,0,0q�$��18(�$��35��$��1���� $ RightToLeft=�$�עיר���� -   $ tb_city��$
��Left=�$��24��$��
340,40,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��189��$��1���� -   $ textBlock1_Copy8��$
��Left=�$
��Wrap=�$	��Top=�$��
437,67,0,0q�$��18(�$	��134��$��1���� $ RightToLeft=�$ �רחוב ומספר בית���� -   $ 	tb_street��$
��Left=�$��24��$��
340,91,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229��$��1���� -   $ textBlock1_Copy9��$
��Left=�$
��Wrap=�$	��Top=�$��479,116,0,0q�$��18(�$��92��$��1���� $ RightToLeft=�$�תאריך לידה���� -   $ lb_day��$
��Left=�$��26��$��343,145,0,0q�$	��Top=�$��59��$��1���� -   $ lb_month��$
��Left=�$��26��$��425,145,0,0q�$	��Top=�$��59��$��1���� -   $ lb_yaer��$
��Left=�$��26��$��510,145,0,0q�$	��Top=�$��59��$��1���� -   $ textBlock1_Copy10��$
��Left=�$
��Wrap=�$	��Top=�$��462,180,0,0q�$��18(�$��1��$	��111���� $ RightToLeft=�$�מצב משפחתי���� -   $ 	lb_family��$
��Left=�$��26��$��340,204,0,0q�$	��Top=�$	��228��$��1���� -   $ textBlock1_Copy11��$
��Left=�$
��Wrap=�$��221,65,0,19q�$��18(�$��45���� $ RightToLeft=�$�
עיסוק���� -   $ lb_prof��$
��Left=�$��26��$��	37,89,0,0q�$	��Top=�$	��228��$��2���� -   	 ��Name$	 cb_smoke��$��מעשן��$
��Left=�$	��Top=�$��18(�$��
204,26,0,0q�$��1���� -   $ textBlock1_Copy13��$
��Left=�$
��Wrap=�$	��Top=�$��
192,64,0,0q�$��18(�$��1��$��74���� $ RightToLeft=�$�בעל חיים���� -   $ 	lb_animal��$
��Left=�$��26��$��	37,90,0,0q�$	��Top=�$	��228��$��1���� -    $ textBlock1_Copy14��$
��Left=�$
��Wrap=�$	��Top=�$��146,128,0,0q�$��18(�$	��117��$��1���� $ RightToLeft=�.��� $�קצת על עצמי���� $	�...���� -!   $ 
tb_general��$
��Left=�$	��103��$��
36,158,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229��$��1���� -"   
 ��Name$
 createNewUser��$��סיום��$
��Left=�$	��Top=�$��87��$��412,272,0,0q�$��29��$��1��