   M S B A M L   `   `   `  ����P  LAuntRosiesBookkeeping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:AuntRosiesBookkeeping.ViewsAuntRosiesBookkeeping.Views  5      T PNumericUpDown, Version=0.1.6.1, Culture=neutral, PublicKeyToken=74df933eb4e7b0ca:-clr-namespace:eisiWare;assembly=NumericUpDowneisiWare 5      4    .AuntRosiesBookkeeping.Views.ManageProductsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:AuntRosiesBookkeeping.Views     5      @custom-clr-namespace:eisiWare;assembly=NumericUpDown     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��0.25* �6   �� 5      �� 5      �� 5      $��0.25* �6   �� 5      $
��0.1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      �� 5      $��0.25* �6   �� 5      �� 5      �� 5      $
��0.1* �6    .+�5   
   �� -   5        $��lblProductList��5      $��Product _List��6&   $��0��6>   $��4��6K   $��Bottom=�6[   �� 5   
   -   5        $��lstProductList��5      $��1��6)   $��4��66   $��2��6F   $��3��6Z   $��5q�6l   6w   �� 5   
   $��Change Product��6   $��1��6+   $��1��6;   $��2��6H   $��1��6\   
���   �.��5      �   5      �� 5       $
��0.1* �6$   �� 5!      $��1.15* �6$   �� 5"      $
��1.2* �6$   �� 5#      �� 5$       5&      �� 5'      $
��0.6* �6'   �� 5(      �� 5)      �� 5*      $��0.25* �6'   .+�5,      �� -   5        $��lblProductName��5,      $��1��6.   $��Right=�6;   .��5-      �� $��WrapWithOverflow=�6    $��Product Name��6@   6V   5.      �� 5/      -   5        $��txtProductName��5/      $��1��60   $��1��6=   $��3��6M   $��5q�6a   �� 50      -   5        $��lblQtyTitle��50      $
��_Qty��6+   $��0��6:   $��2��6J   $��Right=�6W   �� 51      -   5        $��
txtQtyProd��51      $��1��6,   $��2��6<   $��2��6I   �� 52      -   5        $��lblPriceTitle��52      $��_Price��6-   $��3��6>   $��Right=�6K   �� 53      -   5        $��txtPrice��53      $��3��6*   $��1��67   $��5q�6G   $��3��6R   6f   �� 54      -	   5        $��btnChangeRecipe��54      $��_Change Recipe��60   $��4��6I   $��0��6V   $��2��6f   $��5q�6z   6�   �� 55      -
   5        $��btnSaveChanges��55      $��_Save Changes��6/   $��4��6G   $��2��6T   $��2��6d   $��5q�6x   56      57      �� 59   
   -   5        $��btnAddProduct��59      $��_Add Product��6&   $��1��6=   $��3��6M   $��5q�6Z   �� 5:   
   -   5        $��btnRemoveProduct��5:      $��_Remove Product��6)   $��2��6C   $��3��6S   $��5q�6`   5;      5<      