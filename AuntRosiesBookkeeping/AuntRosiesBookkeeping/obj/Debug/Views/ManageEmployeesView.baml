   M S B A M L   `   `   `  ����P  LAuntRosiesBookkeeping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:AuntRosiesBookkeeping.ViewsAuntRosiesBookkeeping.Views  5      5    /AuntRosiesBookkeeping.Views.ManageEmployeesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:AuntRosiesBookkeeping.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��0.75* �6   �� 5      �� 5      $��0.75* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��6* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��0.9* �6   .+�5   
   �� -   5        $��lstEmployees��5      $��1��6&   $��	10,5,10,5q�63   $��4��6F   �� 5    
   -   5        $��lblPayPeriod��5       $��_Pay Period��6$   $��2��6:   $��Right=�6G   $��Center=�6j   �� 5!   
   -   5        $��cmbPayPeriod��5!      $��2��6'   $��1��64   $��2��6D   $��5q�6X   �� 5"   
   -   5        $��btnNewPayPeriod��5"      $��New Pay Period��6(   $��3��6A   $��2��6Q   $��5q�6^   �� 5&   
   -   5        $��lblEmployeeFirstName��5&      $��_First Name��6,   $��3��6B   $��Right=�6O   $��Center=�6r   �� 5'   
   -   5        $��txtEmployeeFirstName��5'      $��3��6.   $��1��6;   $��5q�6K   6V   �� 5*   
   -   5        $��lblEmployeeLastName��5*      $��
_Last Name��6+   $��4��6@   $��Right=�6N   $��Center=�6q   �� 5+   
   -   5        $��txtEmployeeLastName��5+      $��4��6-   $��1��6:   $��5q�6J   6U   �� 5.   
   -	   5        $��lblEmployeeType��5.      $��_Type��6'   $��5��67   $��Right=�6D   $��Center=�6g   �� 5/   
   -
   5        $��cmbEmployeeType��5/      $��5��6*   $��1��67   $��5q�6H   �� 52   
   -   5        $��lblPhoneNumber��52      $��_Phone Number��6&   $��6��6>   $��Right=�6K   $��Center=�6n   �� 53   
   -   5        $��txtPhoneNumber��53      $��6��6(   $��1��65   $��5q�6E   6P   �� 56   
   -   5        $��lblCellPhoneNumber��56      $��Cell Phone _Number��6*   $��7��6G   $��Right=�6T   $��Center=�6w   �� 57   
   -   5        $��txtCellPhoneNumber��57      $��7��6,   $��1��69   $��5q�6I   6T   �� 5:   
   -   5        $��lblHoursWorked��5:      $��Hours _Worked��6&   $��8��6>   $��Right=�6K   $��Center=�6n   �� 5;   
   -   5        $��txtHoursWorked��5;      $��8��6(   $��1��65   $��5q�6E   6P   �� 5>   
   -   5        $��
lblAddress��5>      $��_Address��6"   $��3��65   $��2��6B   $��Right=�6R   $��Center=�6u   �� 5?   
   -   5        $��
txtAddress��5?      $��3��6$   $��3��64   $��5q�6B   6M   �� 5B   
   -   5        $��lblCity��5B      $��_City��6   $��4��6/   $��2��6<   $��Right=�6L   $��Center=�6o   �� 5C   
   -   5        $��txtCity��5C      $��3��6!   $��4��61   $��5q�6?   6J   �� 5F   
   -   5        $��lblProvince��5F      $��	Pro_vince��6#   $��5��67   $��2��6D   $��Right=�6T   $��Center=�6w   �� 5G   
   -   5        $��txtProvince��5G      $��3��6%   $��5��65   $��5q�6B   6M   �� 5J   
   -   5        $��lblPostalCode��5J      $��Pos_tal Code��6%   $��6��6<   $��2��6I   $��Right=�6Y   $��Center=�6|   �� 5K   
   -   5        $��txtPostalCode��5K      $��3��6'   $��6��67   $��5q�6D   6O   �� 5N   
   -   5        $��	lblSalary��5N      $��Employee _Salary��6!   $��7��6<   $��2��6I   $��Right=�6Y   $��Center=�6|   �� 5O   
   -   5        $��	txtSalary��5O      $��7��6#   $��3��60   $��5q�6@   6K   �� 5R   
   -   5        $��btnNew��5R      $��_New Employee��6   $��8��67   $��2��6D   $��5q�6T   �� 5U   
   -   5        $��btnSave��5U      $��Save Changes��6    $��8��67   $��3��6D   $��5q�6T   6_   5W      5Y      