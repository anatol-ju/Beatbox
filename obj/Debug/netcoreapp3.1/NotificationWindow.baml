   M S B A M L   `   `   `  ����  Beatbox     Beatbox.NotificationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      Etelerik1http://schemas.telerik.com/2008/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$  NotificationWindow��5       � SizeToContent$ WidthAndHeight=�6     � ShowInTaskbar$ False��6?    � WindowStyle$
 None=�5       � AllowsTransparency$
 True��6   
������ .��5	      �  J� RenderTransformOrigin$	 0,1&�6   .+�5
   
   �� $��1q�6   
�������
������� �� CornerRadius$ 7��6O   ._�5      � -   5         �Name$
 grid��5      $��	10,5,10,5q�6!   .+�5      �� $��Center=�5      $��Center=�60   .+�5      �� -   5         ��Name$ title��5      �� 5      -   5        	 ��Name$	 	separator��5       $��1��63   
�������$��0,5,0,5q�6P   ��6a   �� 
 �� ElementName$

 grid�� �� Path$ ActualWidth��� 5      -   5        $ content��5      5      5      5       � Triggers 5   
   :� 5       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� -   5         ��Name$ StoryboardLoad��5   "   .��5      �� .��5      W�  �� TargetProperty$ (UIElement.Opacity)�6*    W� From 0.06Z   	 W� To 1.06e    g� Duration$ 0:0:2D�6n   W� 5      -   5        $ (UIElement.Opacity)�5   *    1.06Z    0.06e   $ 0:0:8D�6n    g� 	BeginTime	 0:0:56   6�   5      5      5      :� 5!      $ Mouse.MouseEnter��6   [�5"      �� 5#       �� BeginStoryboardName$ StoryboardLoad��6'   �� 5$      $ StoryboardFade��6'   5&      :� 5(      $ Mouse.MouseLeave��6   .[�5)      �� -   5        $ StoryboardFade��5)   "   .��5*      �� .��5+      W� -	   5        $ (UIElement.Opacity)�5+   *    1.06Z    0.06e   $ 0:0:8D�6n   	 0:0:26   6�   5,      5-      5.      z�52   
   �� 53       �� ScaleY$ 1Q�6   55      56      