   M S B A M L   `   `   `  ����?  ;kurs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:kurskurs  5          kurs.BooksForEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:kurs     5        N� Title$  BooksForEdit��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
DGridBooks��5         AutoGenerateColumns .     
IsReadOnly . ���	#FF807A8A   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *name+6P     5      $ 
Автор��6%   $	 100 6O    64   �� *author+6O     5      $ Жанр��6%   $	 130 6M    63   �� *genre+6M     5      $ Год��6%   $ 80 6K    62   �� *year+6K     5      $/ )Количество книг(всего)��6%   $	 140 6b    6E   �� *
Quantity+6b     5      $7 1Наличие книги в библиотеке��6%   $	 200 6j    6I   �� *Availability+6j     5      $ Стоимость��6%   $	 110 6Q    68   �� *Cost+6Q     5      $" Колл-во страниц��6%   $	 110 6X    6>   �� *Pages+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 285 6)      CellTemplate 5      �� 5      .R�5      �� $��BtnEdit��6=   -   5        $ ��Редактировать��5   %   6L   5!      5#      5%      �� 5&   
   	 �� Orientation$	 
Horizontal=�6   $��1��6/   $��Center=�6=   $��Center=�6Z   .+�5'      o� $	��460��6   .@�5(      �� $��Поиск:��6   �� 5)      -   5        $��TBoxSearch1��5)   2   $	��371��6   $��35��6&   $��22(�6k   $��DemiBold"�6y   5*      5+      �� 5,   
   -   5        $��BtnAdd��5,      $��Добавить��64   $
��Left=�6G   $	��170��6b   
�������
�������$��32(�6�   $��DemiBold"�6�   $��1��6�   ��5-      �� 5.      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5/      �  � Color$ 	#FF6C6280��6#   � 50      $ 	#FF5E586D��6#    � Offset$ 0.961Q�65   � 51      $ 	#FF555881��6#   $ 0.395Q�65   52      54      �� 55   
   -   5        $��BtnDel��55      $��Удалить��64   $
��Left=�6F   $	��175��6a   
�������
�������$��32(�6�   $��DemiBold"�6�   $��
1018,0,0,0q�6�   $��1��6�   ��56      �� 57      $
 0.5,1&�6&   $ 0.5,0&�67   .��58      � $ 	#FF6C6280��6#   � 59      $ 	#FF5E586D��6#   $ 0.961Q�65   � 5:      $ 	#FF555881��6#   $ 0.395Q�65   5;      5=      �� 5>   
   -   5        $��Otchet��5>      $��
Отчёт��64   $
��Left=�6D   $	��130��6_   
�������
�������$��32(�6�   $��DemiBold"�6�   ���	#FF948E8E$��	175,0,0,0q�6�   $��1��6�   5?      5@      