   M S B A M L   `   `   `  ����P  LAuntRosiesBookkeeping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:AuntRosiesBookkeeping.ViewsAuntRosiesBookkeeping.Views  5      T PNumericUpDown, Version=0.1.6.1, Culture=neutral, PublicKeyToken=74df933eb4e7b0ca:-clr-namespace:eisiWare;assembly=NumericUpDowneisiWare 5      1    +AuntRosiesBookkeeping.Views.TransactionView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:AuntRosiesBookkeeping.Views     5      @custom-clr-namespace:eisiWare;assembly=NumericUpDown     5      .��5
      � $��5,5,5,5q�6     � ColumnDefinitions  5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $��0.15* �6   �� 5      $��0.25* �6   �� 5      $��0.15* �6   �� 5      $��0.75* �6   �� 5      $
��0.6* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $��0.75* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��0.50* �6   �� 5      $��0.25* �6   �� 5      �� 5       $
��0.5* �6   �� 5!      �� 5"      $
��0.1* �6   .+�5%   
   �� -   5        $ ��lblCurrentTransactionTitle��5%      $��_Current Transaction��62   $��1��6Q   $��0��6a   $��Bottom=�6n   �� 5&   
   -   5        $��lblProductsTitle��5&      $��	_Products��6(   $��5��6<   $��0��6L   $��Bottom=�6Y   �� 5(   
   -   5        $��lstCurrentTransaction��5(      $��1��60   $��1��6=   $��7��6M   �� 5)   
   -   5        $��lstProducts��5)      $��1��6&   $��5��63   $��2��6C   $��9��6W   �� 5+   
   
���   �$��1q�6%   $��9��69   $��1��6F   $��3��6V   ._�5,      �  5-      �� 5.      �� 5/      �� 50      �� 51        53      �� 54      $��0.65* �6'   �� 55      .+�57      �� -   5        $��lblSubTotalTitle��57      $��
Sub-Total:��60   $��Right=�6E   �� 58      -   5        $��lblSubTotal��58      $��$0.00��6+   $��2��6;   �� 59      -   5        $��lblTaxTitle��59      $
��Tax:��6+   $��1��6:   $��Right=�6G   �� 5:      -   5        $��lblTax��5:      $��$0.00��6&   $��2��66   $��1��6F   �� 5;      -	   5        $��lblRoundingTitle��5;      $��	Rounding:��60   $��2��6D   $��Right=�6Q   �� 5<      -
   5        $��lblRounding��5<      $��$0.00��6+   $��2��6;   $��2��6K   �� 5=      -   5        $��lblTotalTitle��5=      $��Total:��6-   $��3��6>   $��Right=�6K   �� 5>      -   5        $��lblTotal��5>      $��$0.00��6(   $��2��68   $��3��6H   5?      5@      �� 5B   
   -   5        $��lblQty��5B      $
��_Qty��6   $��3��6-   $��1��6=   $��Bottom=�6J   �� 5C   
   -   5        $��btnAddProduct��5C      $��<��6&   $��3��65   $��3��6E   $��5q�6R   �� 5D   
   -   5        $��btnRemoveProduct��5D      $��>��6)   $��3��68   $��4��6H   $��5q�6U   �� 5E   
   -   5        $��btnRemoveAllProduct��5E      $��>>��6,   $��3��6?   $��5��6O   $��5q�6\   �� 5F   
   -   5        $��btnCompleteTransaction��5F      $��Complete _Transaction��6/   $��11��6O   $��6��6]   $��5,5,5,5q�6m   �� 5G   
   -   5         ��Name$ txtQuant��5G      $��3��6$   $��2��64   $��50��6A   $��28��6L   $��
5.2,10,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $��1��6�   $	��Top=�6�   6�   5J      5K      