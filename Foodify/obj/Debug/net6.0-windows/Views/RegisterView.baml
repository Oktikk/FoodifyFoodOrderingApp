   M S B A M L   `   `   `  ����B  >Foodify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:RestaurantProject.ViewsRestaurantProject.Views  5      K*clr-namespace:RestaurantProject.ComponentsRestaurantProject.Components  6B   *    $RestaurantProject.Views.RegisterView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:RestaurantProject.Views     5      A
components*clr-namespace:RestaurantProject.Components     6B   .��5	      � .+�5
   
   � $��Center=�6     � IsSharedSizeScope$
  True��6,    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Center=�6!   .��6>   Zarejestruj się6O   � 5      $��1��6   $��10q�6     � ColumnDefinitions 5      �� 5      $
��auto �6'    z� SharedSizeGroup$ FirstColumn��64   �� 5      $
��auto �6'   $ SecondColumn��64   .+�5      �� $��0��6   $��14(�6(   .��66   Nazwa użytkownika6I   �� 5      $��1��6   $��Center=�6*   $	��150��6L   ��6X   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   5      � 5      $��2��6   $��10q�6     5      �� 5      $
��auto �6'   $ FirstColumn��64   �� 5      $
��auto �6'   $ SecondColumn��64   .+�5      �� $��0��6   $��14(�6(   .��66   Hasło6=   6   0RestaurantProject.Components.BindablePasswordBox  5       $��1��61   $��Center=�5!   1   $	��150��5"   1      Password 5#   1   �� *
Password+$ PropertyChanged=�$ TwoWay=�5$      5%      � 5'      $��3��6   $��Center=�6     5(      �� 5)      $
��auto �6'   �� 5*      $
��auto �6'   .+�5,      �� $��0��6   $��3��6M   $��Center=�6Z   ��6)   �� *RegisterCommand+.��6w   Zarejestruj6�   �� 5-      $��1��6   $��3��6S   $��Center=�6`   ��6)   �� *CancelRegisterCommand+.��6}   Anuluj6�   5.      5/      50      51      