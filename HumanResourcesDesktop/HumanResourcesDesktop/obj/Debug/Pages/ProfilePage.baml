   M S B A M L   `   `   `  ����P  LHumanResourcesDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HumanResourcesDesktop.PagesHumanResourcesDesktop.Pages  5      -    'HumanResourcesDesktop.Pages.ProfilePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:HumanResourcesDesktop.Pages     5         OrangeLight  N� 
Background#  [  5       N� Title$ ProfilePage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� -   5         ��Name$	 FIO��5        	titleText#��[ 6%   �� 5      -   5        $ CountWorkingNumbers��5        normText#��[ 65    J� Opacity$	 0.5Q�6W   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5      $��1��6!      AutoGenerateColumns .    DataGrid#��[ 6J      
IsReadOnly . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Дата начала��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6x   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
date_start+ �� StringFormat$ {0:dd.MM.yyyy}��6x     5      $
 Дата конца��6%   $ * 6u    69   �� *
date_end+$ {0:dd.MM.yyyy}��6u     5      $
 Тип работы��6%   $ * 6W    69   �� *	type.name+6W   5      5      5      