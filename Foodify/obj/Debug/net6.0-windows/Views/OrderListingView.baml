   M S B A M L   `   `   `  ����B  >Foodify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:RestaurantProject.ViewsRestaurantProject.Views  5      .    (RestaurantProject.Views.OrderListingView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:RestaurantProject.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   ���#D9D9D9  5      �� 5      $��1* �6#   �� 5      $��3* �6#   �� 5      $��1* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      �� 5      $
��auto �6    .+�5      �� $��0��6   $��1��6!   $��Center=�61   .��6N   Twoje zamówienia6`   �� 5      -   5         ��Name$ 
OrdersList��5      $��1��6+   $��1��68   $
��0 15q�6H   ��6V   �� *Orders+ �� SelectedItem 6u   �� *SelectedOrder+ �� View 5      �� 5      .P�5      �� $��Zamówienie��6Y    �� DisplayMemberBinding 6)   ��  �� Path$ 	OrderName� �� Width 6m   ��  �� ElementName$ 
OrdersCol1��$ ActualWidth�6�   �� 5      $��Data zamówienia��6Y    6)   �� $ 	OrderDate� 6r   �� $ 
OrdersCol2��$ ActualWidth�6�   5       5"      � 5#      $y�Hidden=�6   ��6'   �� $ 
OrdersList��$ ActualWidth�  5$      �� 5%      $��* �6'   �� 5&      $��* �6'   .+�5)      � -   5        	 �Name$	 
OrdersCol1��5)      $��0��6+   6=   � 5*      -   5        $	 
OrdersCol2��5*      $��1��6+   6=   5+      �� 5,      $��2��6:   $��1��6G   $��Center=�6W   ��6   �� *MakeOrderCommand+.��6t   Złóż nowe zamówienie6�   5-      � 5.   
   $��1��6   ���#FF8552 5/      �� 50      $
��auto �6    �� 51      .+�55      �� $��0��6   $��Center=�6!   .��6>   Szczegóły zamówienia6T   �� 56      -   5        $ 	OrderList��56      $��1��6*   $��35 15q�67   ��6F   �� *SelectedOrderDishes+
 �� UpdateSourceTrigger$
 PropertyChanged=� 57      �� 58      .P�59      �� $��Nazwa dania��6T    6)   �� $
 Name� 6i   �� $ 	OrderCol1��$ ActualWidth�6�   �� 5:      $
��Cena��6U    6)   �� $ Price� 6c   �� $ 	OrderCol2��$ ActualWidth�6�   5;      5=      � 5>      $y�Hidden=�6   ��6'   �� $ 	OrderList��$ ActualWidth�  5?      �� 5@      $��2* �6'   �� 5A      $��1* �6'   .+�5D      � -   5        $	 	OrderCol1��5D      $��0��6*   6<   � 5E      -   5        $	 	OrderCol2��5E      $��1��6*   6<   5F      5G      5H      5I      