   M S B A M L   `   `   `  ����A  =Forsaj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Forsaj.CustomControlsForsaj.CustomControls  5   	       Forsaj.Views.Schedule   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >customcontrols#clr-namespace:Forsaj.CustomControls     5   	   -   5          � Title$  	LoginView��5   	   $	��468��6   $	��400��6(    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 10��6   $��2q�5       � Cursor$
 Hand��6!   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      � 	 � Color$	 #f8c703��6   
 � Offset$
 0Q�6/   � 5      $	 #ee761c��6   $

 0.33Q�6/   � 5      $	 #f8c703��6   $

 0.66Q�6/   � 5      $	 #ee761c��6   $	
 0.1Q�6/   5      ��5   
   �� 5      $	 0,1&�6"   $	 1,0&�63   .��5      � $	 #2b2b29��6   $
 0Q�6/   � 5      $	 #252523��6   $
 1Q�6/   5       ._�5"   
   � $
 Hand��6   $��	0,1,0,-97q�6   .+�5#      �� -   5         ��Name$ btnAddTraining��5#      $�� ��5$      $��0q�5%      $��Добавить��5&      
�������$��12(�5(      $��Comic Sans MS)�5)      $
 Hand��5*      $��236,397,1,121q�5+      ��5-      �� 5.       �� 
TargetType" ��6   .�5/      ��  �� Property � �� �� Value �#ea742367    �� Triggers 50      P� 51       P� Property �@J�IsMouseOver P� Value . . �52   "   ��  � �� �#28AEED6?   53      55      ��58      �� 59       �� 
TargetType" ��6&   .R�5:      �� $	��100��6!   $��30��6-   $ 20��5;      #��z��5<      ._�5=      �� $��Center=�6/   $��Center=�5>      5?      5@      5B      �� 5C      -   5         ��Name$ tbStartTime��5C      $��Center=�6+   $
��Left=�6M   $��130,199,0,0q�6h   $	��Top=�6}   $	��115��6�   $��24��6�    J� Opacity$	 0.5Q�6�    �� TextWrapping$
 Wrap=�6�   �� 5D      $��Тренер��6   
�������$��12(�5F      $��Medium"�5G      $��
Montserrat)�5H      $��130,78,222,466q�5I       �� 5J      $��День недели��6   
�������$��12(�5L      $��Medium"�5M      $��
Montserrat)�5N      $��130,130,189,414q�5O       �� 5P      
�������$��12(�5R      $��Medium"�5S      $��
Montserrat)�5T      $��130,181,149,365q�5U       �� 6:    � Language$ ru-ru�6>   $'�!Начало тренировки��6O   �� 6j   �� 6v   $ ru-ru�6z   6�   �� 5V      -   5        $ btnBackTrainings��5V      $�� ��5W      $��0q�5X      $��
Назад��5Y      
�������$��12(�5[      $��Comic Sans MS)�5\      $
 Hand��5]      $��238,21,-2,489q�5^       J� RenderTransformOrigin$ 0.5,0.5&�6$   z�5_      V� 5`      .~�5a      �� �� 5b      �� 5c       �� Angle$ 0.179Q�6*   T� 5d      5e      ��5h      �� 5i      " ��6   .�5j      ��  � �� �#ea742367    5k      P� 5l       �@J�IsMouseOver . . �5m   "   ��  � �� �#28AEED6?   5n      5p      ��5s      �� 5t      " ��6&   .R�5u      �� $	��100��6!   $��30��6-   $ 20��5v      #��z��5w      $
 Hand��6C   ._�5x      �� $��Center=�6/   $��Center=�5y      5z      5{      5}      �� 5~      $��Описание��6   
�������$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��90,277,246,268q�5�      �� 5�      -   5        $ tbDescription��5�      $��Center=�6-   $
��Left=�6O   $��
89,296,0,0q�6j   $	��Top=�6~   $	��200��6�   $��72��6�   $	 0.5Q�6�   $
 Wrap=�6�   �� 5�      $ ��/Images/ForsajLogo2PNG.png��6   $��-7,2,297,473q�5�      �� 5�      -   5         ��Name$ cbDayOfTheWeek��5�      $��Center=�6/   $
��Left=�6Q   $��130,149,0,0q�6l   $	��Top=�6�   $	��115��6�   $	 0.5Q�6�   $��24��6�   �� 5�      -   5        $ 	cbTrainer��5�      $��Center=�6*   $
��Left=�6L   $��
130,99,0,0q�6g   $	��Top=�6{   $	��115��6�   $	 0.5Q�6�   $��24��6�   �� 5�      
�������$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��130,227,149,315q�5�      �� 6+   $ ru-ru�6/   $#�Дата тренировки��6@   �� 6Y   �� 6e   $ ru-ru�6i   6}   (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ dpDateOfTraining��5�      $
��Left=�63   $��130,247,0,0q�6N   $	��Top=�6c   $	��115��6{   5�      5�      5�      