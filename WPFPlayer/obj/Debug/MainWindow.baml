   M S B A M L   `   `   `  ����D  @WPFPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFPlayer	WPFPlayer  5   	       WPFPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFPlayer     5   	     � Title$  
MainWindow��5   	   $��505.5��6   $	��845��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��65* �6   �� 5      $
��411* �6   .+�5      r� -   5         r�Name$ wpfpanel��5      $
��Left=�6-   $	��370��6H   $	��Top=�6U    r� LoadedBehavior$ Manual=�6m   $	��644��6�   $��
183,31,0,0q�6�   $��1��6�   �� 5      -   5         ��Name$ btn_open��5      $��	Open File��6+   $
��Left=�6?   $	��Top=�6Z   $��80��6r   $��	10,10,0,0q�6}   $��81��6�   $��2��6�   6�   �� 5      -   5        $ btn_play��5      $
��Play��6+   $
��Left=�6:   $	��Top=�6U   $��80��6m   $��10,31.5,0,0q�6x   $��81��6�   $��1��6�   �� 5      -   5        $ 	btn_pause��5      $��Pause��6,   $
��Left=�6<   $	��Top=�6W   $��80��6o   $��10,117.5,0,0q�6z   $��81��6�   $��1��6�   6�   �� 5      -   5         ��Name$ 	balSlider��5      $
��Left=�6,   $	��Top=�6G   $��24��6_   $	��140��6k   $��
687,12,0,0q�6w    � Cursor$
 Hand��6�    � Maximum$	 100Q�6�   �� 5      -   5        $ 	volSlider��5      $
��Left=�6,   $	��Top=�6G   $��24��6_   $	��139��6k   $��
395,10,0,0q�6w    J� RenderTransformOrigin$ 0.516,1.708&�6�   $	 Pen��6�   $	 100Q�6�   6�   �� 5      -   5        $ 
sliderTime��5      $
��Left=�6-   $	��Top=�6H   $��24��6`   $	��432��6l   $��395,2.5,0,0q�6x   $
 Hand��6�   $��1��6�   $	 100Q�6�   �� 5      $��Volume
��6   $
��Left=�63   $	��Top=�6N   $��
292,10,0,0q�6f   $��98��6z   �� 5      -   5        	 ��Name$	 	lblStatus��5      $��Progress��6+   $
��Left=�6>   $	��Top=�6Y   $��292,0.5,0,0q�6q   $��98��6�   $
 Hand��6�   $��1��6�   �� 5      $��Balance

��6   $
��Left=�6>   $	��Top=�6Y   $��
589,10,0,0q�6q   $��98��6�   $��2��6�   �� 5      -	   5        $ btn_stop��5      $
��Stop��6+   $
��Left=�6:   $	��Top=�6U   $��80��6m   $��10,203.5,0,0q�6x   $��81��6�   $��1��6�   6�   �� 5   
   -
   5        $ btn_fullscreen��5      $��Toggle Fullscreen��6)   $
��Left=�6E   $	��Top=�6`   $��80��6x   $��10,289.5,0,0q�6�   $��81��6�   $��1��6�   5      5      