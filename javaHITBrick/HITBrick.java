package lo;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.event.MouseInputListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Color;
import javax.swing.JRadioButton;
import javax.swing.JSlider;
import javax.swing.JScrollBar;
import javax.swing.border.CompoundBorder;
import javax.swing.border.BevelBorder;
import javax.swing.border.LineBorder;

public class HITBrick extends JFrame implements MouseInputListener, KeyListener {

	private JPanel ccc;
	JLabel aaa;
	JLabel bbb;
	int barx = 0;
	int bary = 0;
	double ballx = 0;
	double bally = 0;
	double bxmv = 0;
	double bymv = 0;
	private JLabel BARR;
	final int  xBricksp=50;
	final int yBricksp=28;
	final int Brickwid=58;
	final int Brickheit=23;
	final int columnBrick=9;
	final int rowBrick=5;
	Brick[][] bricks;
	int totalb=0;

	Timer timer;
	int locax;
	int locay;
	int Ulo;
	int Dlo;
	int Llo;
	int Rlo;

	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					HITBrick frame = new HITBrick();
					frame.setLocationRelativeTo(null);
					frame.setVisible(true);		
					} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	public HITBrick() {
		setResizable(false);	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 646, 426);
		ccc = new JPanel();
		ccc.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(ccc);
		ccc.setLayout(null);

		aaa = new JLabel("New label");
		aaa.setBounds(10, 10, 46, 15);
		ccc.add(aaa);

		bbb = new JLabel("New label");
		bbb.setBounds(66, 10, 46, 15);
		ccc.add(bbb);
		
		JRadioButton rdbtnNewRadioButton = new JRadioButton("");
		rdbtnNewRadioButton.setBounds(203, 204, 17, 15);
		ccc.add(rdbtnNewRadioButton);
		
		BARR = new JLabel("");
		BARR.setBorder(new CompoundBorder(new BevelBorder(BevelBorder.LOWERED, new Color(0, 0, 0), new Color(0, 0, 0), new Color(0, 0, 0), new Color(0, 0, 0)), new LineBorder(new Color(255, 255, 0), 3)));
		BARR.setOpaque(true);
		BARR.setBackground(Color.RED);
		BARR.setBounds(244, 354, 80, 23);
		ccc.add(BARR);

        setFocusable(true);
		addKeyListener(this);

		addMouseListener(this);
		addMouseMotionListener(this);
		
		bricks=new Brick[columnBrick][rowBrick];
		
		newcb();
		

		
		
		barx=BARR.getX();
		bary=BARR.getY();

		ballx=(long)rdbtnNewRadioButton.getX();
		bally=(long)rdbtnNewRadioButton.getY();

		locax=((int)ballx-xBricksp+Brickwid)/Brickwid-1;
		locay=((int)bally-yBricksp+Brickheit)/Brickheit-1;
		
		 Ulo=((int)bally-4-yBricksp+Brickheit)/Brickheit-1;
		 Dlo=((int)bally+4-yBricksp+Brickheit)/Brickheit-1;
		 Llo=((int)ballx-4-xBricksp+Brickwid)/Brickwid-1;
		 Rlo=((int)ballx+4-xBricksp+Brickwid)/Brickwid-1;
		
		bymv=0.4;
		
		timer = new Timer();

		class tks extends TimerTask {
			public void run() {
//				646 426
				if(ballx>=630||ballx<=0) {bxmv*=-1;}
				if(bally>=385||bally<=0) {bymv*=-1;}
//				if(bally>=385) {JOptionPane.showMessageDialog(null, "youlose");
//				ReSet();}
				
				if((ballx>=barx-20&&ballx<=(barx+100))&&(bally+5>=bary&&bally+5<=(bary+bymv))) 
				{
					bymv*=-1;
					int c=barx+40;
					bxmv+=(ballx-c)/100;
				}
				
				if(bxmv>0.5) {
					bxmv=0.5;
				}else if (bxmv<-0.5){
					bxmv=-0.5;}
				

				
				if(bally+4>=(Dlo+1)*Brickheit+yBricksp) {
					try {
					if(bricks[locax][locay+1].dis) {
						bymv*=-1;
						bally+=bymv*2;
						bkhit(bricks[locax][locay+1]);
						ccc.repaint();
					}}catch (Exception e) {
					}
				}
				
				if(bally-4<=Ulo*Brickheit+yBricksp) {
					try {
					if(bricks[locax][locay-1].dis) {
						bymv*=-1;
						bally+=bymv*2;
						bkhit(bricks[locax][locay-1]);
						ccc.repaint();
					}}catch (Exception e) {
					}
				}
				
				if(ballx+4>=(Rlo+1)*Brickwid+xBricksp) {
					try {
					if(bricks[locax+1][locay].dis) {
						bxmv*=-1;
						ballx+=bxmv*2;
						bkhit(bricks[locax+1][locay]);
						ccc.repaint();
					}}catch (Exception e) {
					}
				}
				
				if(ballx-4<=Llo*Brickwid+xBricksp) {
					try {
					if(bricks[locax-1][locay].dis) {
						bxmv*=-1;
						ballx+=bxmv*2;
						bkhit(bricks[locax-1][locay]);
						ccc.repaint();
					}}catch (Exception e) {
					}
				}

				locax=((int)ballx-xBricksp+Brickwid)/Brickwid-1;
				locay=((int)bally-yBricksp+Brickheit)/Brickheit-1;

				 Ulo=((int)bally-4-yBricksp+Brickheit)/Brickheit-1;
				 Dlo=((int)bally+4-yBricksp+Brickheit)/Brickheit-1;
				 Llo=((int)ballx-4-xBricksp+Brickwid)/Brickwid-1;
				 Rlo=((int)ballx+4-xBricksp+Brickwid)/Brickwid-1;
				 
				System.out.print(locax);
				System.out.println(","+locay);
				
				ballx+=bxmv;
				bally+=bymv;
				
				 
				int xx=(int)ballx;
				int yy=(int)bally;
				rdbtnNewRadioButton.setBounds(xx-10,yy-8,17,15);
				validate();
				
				if(totalb==0) {
					JOptionPane.showMessageDialog(null, "WIN");
					ReSet();
				}
			}

			private void ReSet() {
				totalb=0;
				for(Brick[] a:bricks) {
					for(Brick b:a) {
						ccc.remove(b);
					}
				}
				
				
				bymv=0.4;
				bxmv=0;
				bally=204;
				ballx=203;
				newcb();
				repaint();
			}

		}
		timer.schedule(new tks(), 0, 1);

	};
	
	public void bkhit(Brick brick) {

		switch (brick.rank) {
		case 1:
			brick.dis=false;
			totalb--;
			brick.rank--;
			ccc.remove(brick);
			break;
		case 2:
			brick.setBackground(Color.YELLOW);
			brick.rank--;			
			break;
		case 3:
			
			break;

		default:
			break;
		}
		
	}

	private void newcb() {		
		for(int i=0;i<rowBrick;i++) {
		for(int j=0;j<columnBrick;j++) {
			Brick bk = new Brick();
			bk.rank=(int)(Math.random()*4);
			bk.setBorder(new LineBorder(Color.BLACK));
			switch (bk.rank) {
			case 0:
				bk.setBackground(Color.YELLOW);
				bk.rank=1;
				totalb++;
				break;
			case 1:
				bk.setBackground(Color.YELLOW);
				bk.rank=1;
				totalb++;
				break;
			case 2:
				bk.setBackground(Color.red);
				totalb++;				
				break;
			case 3:
				bk.setBackground(Color.black);
				break;

			default:
				break;
			}
			bk.setBounds(xBricksp+Brickwid*j, yBricksp+Brickheit*i, Brickwid, Brickheit);
			bk.dis=true;
			ccc.add(bk);
			bricks[j][i]=bk;
		}
	}
		
	}

	@Override
	public void mouseClicked(java.awt.event.MouseEvent arg0) {}
	@Override
	public void mouseEntered(java.awt.event.MouseEvent arg0) {}
	@Override
	public void mouseExited(java.awt.event.MouseEvent arg0) {}
	@Override
	public void mousePressed(java.awt.event.MouseEvent arg0) {}
	@Override
	public void mouseReleased(java.awt.event.MouseEvent arg0) {}
	@Override
	public void mouseDragged(java.awt.event.MouseEvent arg0) {}
	@Override
	public void mouseMoved(java.awt.event.MouseEvent e) {
		aaa.setText("X:" + e.getX());
		bbb.setText("Y:" + e.getY());
		
		barx=e.getX()-40;

		BARR.setBounds(barx, 354, 80, 23);

	}

	@Override
	public void keyPressed(KeyEvent e) {
		int kk=e.getKeyCode();
		System.out.println(kk);
		
		if(kk==37) {

			barx-=10;
		}
		else if(kk==39) {
			barx+=10;
			
		}

		BARR.setBounds(barx, 354, 80, 23);
		
	}

	@Override
	public void keyReleased(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void keyTyped(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}




}
class Brick extends JPanel{
	boolean dis;
	int rank;
	
}
