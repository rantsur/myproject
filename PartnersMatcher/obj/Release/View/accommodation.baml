   M S B A M L   `   `   `  ���� J  FPartnersMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PartnersMatcher.ViewPartnersMatcher.View  (    "PartnersMatcher.View.accommodation   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:PartnersMatcher.View     .��� 
�������$��4,0,-4,0q�.+�(  "System.Windows.Controls.DatePicker  -      Name$
  Date��$��490,299,480,241q�   FirstDayOfWeek$ Sunday=��� -    ��Name$ 
textBlock1��$
��Left=�$
��Wrap=�$	��Top=�$��
967,53,0,0q�$��18(�$	��128����  �� FlowDirection$ RightToLeft=�$�מחיר השכירות���� -    ��Name$ tb_numberOfUsers��$
��Left=�$��25��$��860,154,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��229��-  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=��� -   $ textBlock1_Copy��$
��Left=�$
��Wrap=�$	��Top=�$��939,121,0,0q�$��18(�$	��167���� $ RightToLeft=�.��� $�	מספר ���� $�חדרים ���� $�
בדירה���� -   $ tb_cost��$
��Left=�$��25��$��
860,88,0,0q�$	��Top=�$	��229���� -   $ textBlock1_Copy1��$
��Left=�$
��Wrap=�$	��Top=�$��996,259,0,0q�$��18(�$��93�� J� RenderTransformOrigin$ 2.954,1.404&�$��44���� $ RightToLeft=�$�הוסף שותף���� -   $ 
tb_partner��$
��Left=�$��25��$��965,291,0,0q�$	��Top=�$	��122���� -   $ textBlock1_Copy2��$
��Left=�$
��Wrap=�$	��Top=�$��959,325,0,0q�$��18(�$	��131���� $ RightToLeft=�$�השותפים בדירה���� -	    ��Name$ tb_partnersList��$
��Left=�$	��146��$��803,363,0,0q�$	��Top=�$	��281���� -
   $ 
tb_address��$
��Left=�$��25��$��396,104,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229���� -   $	 lll��$
��Left=�$
��Wrap=�$��Bottom=�$��721,0,0,562q�$��18(�$	��150��$��54��$ 0.533,1.185&��� $ RightToLeft=�.��� $�כתובת ���� $�
הדירה���� -   $ textBlock1_Copy7��$
��Left=�$
��Wrap=�$	��Top=�$��
739,69,0,0q�$��18(�$��35���� $ RightToLeft=�$�עיר���� -   $ tb_city��$
��Left=�$��24��$��
539,69,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��189���� -   $ textBlock1_Copy8��$
��Left=�$
��Wrap=�$	��Top=�$��640,105,0,0q�$��18(�$	��134���� $ RightToLeft=�$ �רחוב ומספר בית���� -   $ textBlock1_Copy9��$
��Left=�$
��Wrap=�$	��Top=�$��566,266,0,0q�$��18(�$	��154���� $ RightToLeft=�.��� $�תאריך ���� $�כניסה לדירה���� -   	 ��Name$	 lb_furniture��$
��Left=�$��26��$��491,366,0,0q�$	��Top=�$	��228���� -   
 ��Name$
 cb_smoke��$��מעשנים��$
��Left=�$	��Top=�$��18(�$��635,158,0,0q��� -   $ textBlock1_Copy13��$
��Left=�$
��Wrap=�$	��Top=�$��
226,48,0,0q�$��18(�$��90���� $ RightToLeft=�$�מצב הדירה���� -   $	 lb_condition��$
��Left=�$��26��$��	79,87,0,0q�$	��Top=�$	��228���� -   $ textBlock1_Copy14��$
��Left=�$
��Wrap=�$	��Top=�$��126,137,0,0q�$��18(�$	��190���� $ RightToLeft=�.��� $)�#תיאור כללי של הדירה���� $	�...���� -   $ 
tb_general��$
��Left=�$	��202��$��
22,166,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��294���� -    ��Name$ createNewAd��$��פרסם��$��16(�$
��Left=�$	��Top=�$��87��$��
22,466,0,0q�$��30���� -   $
 
cb_elvator��$��
מעלית��$
��Left=�$	��Top=�$��18(�$��532,158,0,0q��� -   $ 	addPhotos��$+��%הוסף תמונות של הדירה��$��16(�$
��Left=�$	��Top=�$	��187��$��126,394,0,0q�$��39���� -   $ addNewPartner��$��הוסף��$��16(�$
��Left=�$	��Top=�$��87��$��853,291,0,0q�$��29���� -   $ tb_size��$
��Left=�$��25��$��491,229,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229���� -   $ textBlock1_Copy3��$
��Left=�$
��Wrap=�$	��Top=�$��632,197,0,0q�$��18(�$��94���� $ RightToLeft=�$�גודל הדירה���� -   $ textBlock1_Copy4��$
��Left=�$
��Wrap=�$	��Top=�$��626,330,0,0q�$��18(�$	��110��$��24���� $ RightToLeft=�$�ריהוט בדירה���� -   $ tb_numberOfUsers_Copy��$
��Left=�$��25��$��860,222,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��229��$
 None=��� -   $ textBlock1_Copy5��$
��Left=�$
��Wrap=�$	��Top=�$��912,191,0,0q�$��18(�$	��181��$ 0.5,0.5&�$��25��$(��"מספר שותפים נדרשים��