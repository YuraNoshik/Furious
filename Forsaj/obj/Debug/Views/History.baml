   M S B A M L   `   `   `  ����A  =Forsaj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Forsaj.ViewsForsaj.Views  5          Forsaj.Views.History   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Forsaj.Views     5        N� Title$  History��5	      .��5      � .+�5   
   �� -   5         ��Name$ tbSearchHistory��5      $��Center=�6+   $
��Left=�6M   $��1,21,0,0q�6h   $	��Top=�6z   $	��206��6�   $��27��6�    J� Opacity$	 0.5Q�6�    �� TextWrapping$
 Wrap=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	dpHistory��5      $
��Left=�6(   $��Center=�6C   $��
417,21,0,0q�6e   $	��Top=�6y   $��29��6�   $	��162��6�   �� 5   
   $��Поиск клиента��6   
�������$��12(�5      $��
Montserrat)�5      $��2,1,457,462q�5       J� RenderTransformOrigin$ 	0.5,0.533&�6"   �� 5   
   $��Поиск по дате��6   
�������$��12(�5      $��
Montserrat)�5      $��417,1,41,462q�5      $ 	0.5,0.533&�6#   �� 5   
   -   5         ��Name$ listHistory��5      $��	-2,59,2,2q�6(   ���#a4a4a4$	��586��6P    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%x   '��       �� 5      " ��6   .�5      �� 	 � ��

 �   �63   �� 5      	 � ��$
 16(�61   5      5       �� View 5      �� 5       .P�5!      �� $��Имя��6%    �� Width$	 120��6f    �� DisplayMemberBinding 62   �� *Clients.clientName+ �� CellTemplate 5"      �� 5#      .R�5$   "   �� ���#DDDDDD��6,   �� *Clients.clientName+6P   5%      5'      �� 5(      $��Фамилия��6%   $	 140��6m    66   �� *Clients.clientSurname+ 5)      �� 5*      .R�5+   "   �� ���#DDDDDD��6,   �� *Clients.clientSurname+6S   5,      5.      �� 5/      $��Отчество��6%   $	 160��6q    67   �� *Clients.clientPatronymic+ 50      �� 51      .R�52   "   �� ���#DDDDDD��6,   �� *Clients.clientPatronymic+6V   53      55      �� 56      $��Дата��6%   $ 90��6}    63   �� *	visitDate+ �� StringFormat$ {0:dd.MM.yyyy}�� 57      �� 58      .R�59   "   �� ���#DDDDDD �� TextAlignment$ Center=�6\   ��6,   �� *	visitDate+6\   5:      5<      �� 5=      $��
Время��6%   $ 70��6{    64   �� *	visitTime+$ 
{0:hh\:mm}�� 5>      �� 5?      .R�5@   "   �� ���#DDDDDD$ Center=�6x   ��6,   �� *	visitTime+$ 
{0:hh\:mm}��6x   5A      5C      5D      5F      �� 5G   
   -   5         ��Name$ lbAmountVisits��5G      
�������$��16(�5I      $��Medium"�5J      $��
Montserrat)�5K      $��218,27,204,440q�5L      $ 	0.5,0.533&�6%   �� 5M   
   -   5         ��Name$ picRefreshDateHistory��5M      $��383,25,178,437q�6/   $��/refresh123.png��6G   $
��Fill=�6`   6o   5O      5P      