   M S B A M L   `   `   `  ����P  LAuntRosiesBookkeeping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:AuntRosiesBookkeeping.ViewsAuntRosiesBookkeeping.Views  5   	   T PNumericUpDown, Version=0.1.6.1, Culture=neutral, PublicKeyToken=74df933eb4e7b0ca:-clr-namespace:eisiWare;assembly=NumericUpDowneisiWare 5      ,    &AuntRosiesBookkeeping.Views.RecipeView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:AuntRosiesBookkeeping.Views     5   	   @custom-clr-namespace:eisiWare;assembly=NumericUpDown     5        � Title$  Recipe��5	      $	��496��6   $	��696��6-   $	��496��6<   $	��696��6L   
�������.��5
      � $��5,5,5,5q�6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $��0.15* �6   �� 5      $��0.25* �6   �� 5      $��0.15* �6   �� 5      $��0.75* �6   �� 5      $
��0.6* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $��0.75* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��0.50* �6   �� 5      $��0.25* �6   �� 5      �� 5       $
��0.5* �6   �� 5!      �� 5"      $
��0.1* �6   .+�5%   
   �� -   5        $��lblIngredients��5%      $��_Recipe��6&   $��1��68   $��0��6H   $��Bottom=�6U   �� 5&   
   -   5        $��lblIngredientTitle��5&      $��_Ingredients��6*   $��5��6A   $��0��6Q   $��Bottom=�6^   �� 5(   
   -   5        $��	lstRecipe��5(      $��1��6$   $��1��61   $��9��6A   �� 5)   
   -   5        $��lstIngredients��5)      $��1��6)   $��5��66   $��2��6F   $��9��6Z   �� 5,   
   -   5        $��lblQty��5,      $
��_Qty��6   $��3��6-   $��1��6=   $��Bottom=�6J   �� 5-   
   -   5        $��btnAddIngredient��5-      $��<��6)   $��3��68   $��3��6H   $��5q�6U   �� 5.   
   -   5        $��btnRemoveIngredient��5.      $��>��6,   $��3��6;   $��4��6K   $��5q�6X   �� 5/   
   -   5        $��btnRemoveAllIngredients��5/      $��>>��60   $��3��6C   $��5��6S   $��5q�6`   �� 50   
   -	   5        $��btnSave��50      $��_Save Recipe��6    $��11��67   $��6��6E   $��5,5,5,5q�6U   �� 51   
   -
   5         ��Name$ txtQuant��51      $��3��6$   $��2��64   $��50��6A   $��28��6L   $��
5.2,10,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $��1��6�   $	��Top=�6�   6�   53      54      