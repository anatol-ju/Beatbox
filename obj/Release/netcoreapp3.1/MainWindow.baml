   M S B A M L   `   `   `  ���� B  >Beatbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BeatboxBeatbox      Beatbox.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Beatbox     -     �Name$  	MainFrame�� � Title$* $Beatbox - The Ultimate Damage-Dealer��$	��350��$	��800��$	��350��$	��800�� � 
ResizeMode$ 	CanResize=� � 	Resources    MilestoneTemplate � ColumnDefinitions � RowDefinitions �� Path �� ElementName  StringTemplate  TextBlockTemplate  ImageTemplate!  Beatbox.LogTemplateSelector  logTemplateSelector �� 
TargetType	 �� BasedOn
 �� Triggers �� Binding �� Self �� RelativeSource �� Value �� Property �� Value��%?  &	        &	 S    &	 �    &	 �    &	     '��     7���� .R��  �� �� ��  �� �� �� .+��� $��0��$��0��$
��Bold"�
����� ����� $
 Name��� $��Italic$�$��1��$��0��$��3��$��Center=�$��Center=�$
��Wrap=�
����ح����� $ Description����� $	 log��$ ActualWidth��� $��2��$��2��$��Right=�
����� ����� $ DateTime��� .R��� $��5,5,5,5q�$
��Left=����� �� .R��� $��5,5,5,5q�$
��Left=����� $
 Text��� .R��� $��Uniform=�$��Center=�$	��200��$��5,5,5,5q����� $ Source�  �� " ��8	   
 ��  �� # Z $ Items.Count� 0.a���  � �� �� .R��� $��Center=�$��Center=�
�������$
��Wrap=�" To start the game, click on the �� .�Start button above and �� .�Stop
 to pause.�� rpThe progress bar shows when you level up and gain points. Use these increase your stats and improve your damage.�� usClick on the grey area on bottom-center when both arrows meet to make the attack a critical hit with double damage..��]� -    ]�Name$ ContentFrame��.+�o� $	��Top=�.@�m� $
��File��.@�m� -   $
��_New��m� -   $��_Load��m� -   $��_Save���� m� -   $��_Exit��m� $
��Edit��.@�m� -   $��Reset Points��m� -   $
��Info��m� -	   $��
Milestones��� -
    �Name$ 	StatusBar��$��Bottom=�.+�� -    �Name$ XPBar��$��20�� � Minimum$ 0Q� � Maximum$	 100Q��� $��Center=�$��Center=��� $�Current Progress: �� �� ��� $ 	CurrentXP� �� $�/�� �� ��� $ MaxDamageValueForLevel� �� $� (�� �� ��� $ XPBar��$ Value� �� $�%)��z��� -   
XPBarScale���  �� $��0.25* ��� $
��0.5* ��� $��0.25* �.+�(� $��0��$��Center=� (� Stretch$ Uniform=�.��� -   $ InfoGrid��$��10,10,10,10q� �� $
��0.5* ��� $
��0.2* ��� $
��0.3* � �� $
��Auto ��� �� $��5 ��� �� $��5 ��� �� $��5 ��� �� $��20 ��� �� �� �� �� �� $
��Auto �.+��� $��Level:��$
��Bold"�$��0��$��1���� $��Attack Power:��$��0��$��3���� $��Critical Rating:��$��0��$��5���� $��Haste Rating:��$��0��$��7���� $��Damage:��$��0��$��9���� $��Crit Chance (%):��$��0��$��10���� $��Attack Rate (sec):��$��0��$��11���� $��Damage/sec:��$��0��$��12���� $��Record:��$��0��$��13���� -    ��Name$ ValueAP��$��1��$��1��$��3��$��Right=��� -   $ ValueCR��$��1��$��1��$��5��$��Right=��� -   $ ValueHR��$��1��$��1��$��7��$��Right=��� -    ��Name$ 
IncrBttnAP��$��2��$��3��.���� $��2,0,2,0q�
Increase�� -   $ 
IncrBttnCR��$��2��$��5��.���� $��2,0,2,0q�
Increase�� -   $ 
IncrBttnHR��$��2��$��7��.���� $��2,0,2,0q�
Increase�� -   $ 
LevelValue��$��1��$
��Bold"�$��2��$��1��$��Right=��� -   $ ValueCurrentDamage��$��0��$��2��$��9��$��Right=��� -   $ ValueCritChance��$��0��$��2��$��10��$��Right=��� -   $ ValueAttackRate��$��0��$��2��$��11��$��Right=��� -   $ DamagePerSecondValue��$��0��$��2��$��12��$��Right=��� -   $ ValueRecordDamage��$��0��$��2��$��13��$��Right=�� $��1��$��
10,10,10,0q�.+�� z���  �� $��0.05* ��� �� $��0.25* �.+�� $��Stretch=�$��0�� �� �� $
��0.3* ��� .+��� -    ��Name$ 
ArrowImage��$��/res/arrow_down.png��$��1��(� -    (�Name$ AnimationPanel��$��1��$��Bottom=�.��� $��0,0,0,10q�.+��� $��/res/gradient_circle.png�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$
 0.35Q�T� �� -   $ rotatingArrow��$��Uniform=�$��/res/arrow_up.png��$ 0.5,13.6&�$��	0,0,0,520q�$��Center=�$��Center=�$��20��$��20��z�V� .~��� �� �� $ 0Q�T� (� $��1��$ Uniform=�$��75,75,75,75q�.���� -    ��Name$ ExplosionLabel��$��Center=�$��Center=�$��Yu Gothic UI)�(� $��1��$ Uniform=�$��75,0,75,150q�.���� -   $ 	CritLabel��$	��Top=�$��Center=�$��Yu Gothic UI)�$��Italic$��� -   $��2��
����������	#FFBCBCBC �� CornerRadius$ 10��._��� $��Center=�$��Center=� �� TextAlignment$ Center=�.,Left-Click on this area when the arrows meet�� -+to convert next hit into a critical strike.� -    $ LogGrid��$��2��$��10,10,10,10q� ��  �� $��0.15* ��� .+��� -!   $ StartStopButton��$��0��$��0��.��(� .���� Start�� -"     ��Name$  ScrollViewer��$��0��$��1��$��	0,10,0,10q�.��!clr-namespace:BeatboxBeatbox  �� :x,http://schemas.microsoft.com/winfx/2006/xaml     'localclr-namespace:Beatbox     -#   ! ��Name$	! log��$��Stretch=�$" �� IsSynchronizedWithCurrentItem$
" TrueY�#��[ ���� $ ScrollViewer��$ ActualWidth�