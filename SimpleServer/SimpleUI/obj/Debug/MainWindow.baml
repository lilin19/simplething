   M S B A M L   `   `   `  ����C  ?SimpleUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SimpleUISimpleUI  5   	       SimpleUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SimpleUI     5   	     � Title$  Simplething��5   	   $	��380��6   $	��600��6*   $	��600��66   $	��380��6E   .��5	      � $��0,0,2,1.847q�6    J� RenderTransformOrigin$ 0.499,0.627&�6     � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5       � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      $��0* �6   �� 5      $
��100* �6   �� 5      $��0* �6   �� 5      $	��11* �6   .+�5   
   �� -   5         ��Name$ Submit��5      $��Submit��6!   $
��Left=�62   $��17.96��6M   $��470.446,10,0,0q�6\   $	��Top=�6t   $��109.554��6�   
���   ����	#FF4D4D4D
�������$��4��6�   $��2��6�   �� 5   
   -   5         ��Name$ Input��5      $
��Left=�6!   $��17.96��6<   $��	10,10,0,0q�6K    �� TextWrapping$ NoWrap=�6^   $	��Top=�6t   $��99.542��6�   
����������	#FF1A4EE8$��4��6�   $��2��6�   .��6   � LayoutTransform 5      u� 5       u� Matrix$ Identityx�6"   .��5   '   5      (� 5   
   $��2��6   $��2��6"   $��2��6/   $��10,5.163,10,0q�6@   .��5      �� -   5        	 ��Name$	 Screen��5      $��2��6$   $�� ��68   $��1��6C   $
��Left=�6S   $��0,0,0,0q�6n   $	��Top=�6   #��� ��6�   $
��Auto=�6�   $
��Auto=�6  $��489.474��6C  $	��250��6S     
Transform1#z��   6`  
 � 	Resources
 5      ��%,   &	        u� 5      $ Identityx�69   5        5!      V� 5"      .~�5#      �� �� 5$      �� 5%      T� 5&      5'       J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$ 1Q�6'      ShadowDepth$ 1Q�66   5,      5-      o� 5.   
   $��3��6   $
��Left=�6#   $��17.982��6>   $��0,0.036,0,0q�6N   $	��Top=�6c   $��2��6{   .@�5/      m� $��_File��6   .@�50      m� $��_Open��6   m� 51      $��_Close��6   m� 52      $��_Save��6   53      54      56      57      