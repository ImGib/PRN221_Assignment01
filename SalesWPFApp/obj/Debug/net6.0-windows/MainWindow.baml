   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	       SalesWPFApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  Login��5   	   $	��250��6   $	��400��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      ]� 
�������.+�5   
   � $	��Top=�6   $	��150��6$    � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��75 �6    �� 5      $��75 �6    .+�5      �� -   5         ��Name$ lbEmail��5      $��0��6%   $��0��62   $��Right=�5      $��Center=�5      .��6/   	Email :68   �� 5      -   5         ��Name$ txtEmail��5      $��0��6(   $��1��65   $��Center=�5      $��Center=�5      $��0��61   $	��200��5      $��25��6"   �� 5      -   5        $ 
lbPassword��5      $��1��6(   $��0��65   $��Right=�5      $��Center=�5      .��6/   
Password :6;   G� 5      -   5         G�Name$ txtPassword��5      $��1��6/   $��1��6<   $��Center=�5      $��Center=�5        G� PasswordChar$ *��60   $��1��6A   $	��200��5!      $��25��6!   5"      �� 5$   
   	 �� Orientation$	 
Horizontal=�6   $��Center=�6.   .+�5%      �� -   5        
 ��Name$
 btnLogin��5%      $��30��6'   $��60��63   ���	#FFBFF5E3 �� 	IsDefault$
 True��5&   (   $��0,0,25,0q�69   .��6K   Login6R   �� 5'      -   5        $
 btnRegister��5'      $��30��6*   $��60��66   ���	#FFBFF5E3.��5(   +   
Register65   5)      5+      5,      