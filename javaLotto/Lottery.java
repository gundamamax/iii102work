import java.awt.BorderLayout;
import java.awt.EventQueue;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import java.awt.Color;
import javax.swing.JScrollPane;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.SystemColor;
import javax.swing.JButton;
import java.awt.Font;
import javax.swing.border.BevelBorder;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.SwingConstants;
import java.awt.event.ActionListener;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.ListIterator;
import java.awt.event.ActionEvent;
import javax.swing.border.LineBorder;
import javax.swing.JTextField;
import javax.swing.JCheckBox;
import javax.swing.JDialog;
import javax.swing.JComboBox;
import javax.swing.DefaultComboBoxModel;

public class Lottery extends JFrame {

	private JPanel contentPane;
	public int[] randcompose = new int[7];
	public LinkedList<lotterycompose> LCM = new LinkedList<>();
	private JTextField textField;
	private JTextField textField_1;
	private JLabel winstate;
	private JLabel wsta1;
	private JLabel wsta2;
	private JLabel wsta3;
	private JLabel wsta4;
	private JLabel wsta5;
	private JLabel wsta6;
	private JLabel wsta7;
	private JLabel wsta8;
	private JLabel lblNewLabel_2;
	private JCheckBox checkBox;
	private JLabel lblNewLabel;
	private JLabel LBLCOUNT;
	private JComboBox comboBox;

	JScrollPane scrollPane;
	JPanel FLOWPPANEL = new JPanel();
	private int WIN1 = 100000000;
	private int WIN2 = 800000;
	private int WIN3 = 50000;
	private int WIN4 = 15000;
	private final int WIN5 = 2000;
	private final int WIN6 = 1000;
	private final int WIN7 = 400;
	private long[] wincm = new long[9];
	private int themax = 1000;
	private long count = 0;
	private long totalwin = 0;
	private long totalmoney = 100000000;
	private boolean NewCIng = false;
	private String[] btntxt = new String[49];
	private boolean cstop = false;
	//SystemColor.LIGHT_GRAY;
	//new Color(250, 250, 250);
	private Color C_cmpanel = SystemColor.LIGHT_GRAY;
	private Color C_cmnum = new Color(250, 250, 250);
	private Color C_cmdel = new Color(255, 228, 225);
	private Color C_cmrandom = new Color(175, 238, 238);
	private Color C_cmstate = new Color(153, 255, 204);
	private Color C_cmnumselet = SystemColor.RED;

	class NumberBTNAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			lotbtn JB = (lotbtn) e.getSource();
			// System.out.println(JB.group.num);
			int cm = JB.group.num;
			lotterycompose com = LCM.get(cm);
			if (!JB.isSelected()) 
			{
				if (com.numbtncount < 6) {
					JB.setSelected(true);
					JB.setBackground(C_cmnumselet);
					com.numbtncount++;
					com.STAT.setText(Integer.toString(com.numbtncount) + "個號碼");
					com.win = 0;
				}
			} else {
				JB.setSelected(false);
				JB.setBackground(C_cmnum);
				com.numbtncount--;
				com.STAT.setText(Integer.toString(com.numbtncount) + "個號碼");
				com.win = 0;
			}
		}
	}

	class DELBTNAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			if (!NewCIng) {
				lotbtn JB = (lotbtn) e.getSource();
				int com = JB.group.num;

				int i = 0;
				LCM.remove(com);

				for (lotterycompose cm : LCM) {

					cm.group.num = i;
					i++;
				}
				LBLCOUNT.setText("現有選號數:" + Integer.toString(LCM.size()));

				FLOWPPANEL.remove(com);
				FLOWPPANEL.setPreferredSize(
						new Dimension(800, 5 + 105 * (LCM.size())));

				FLOWPPANEL.validate();
				FLOWPPANEL.updateUI();
			}
		}
	}

	class RANDOMAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			lotbtn JB = (lotbtn) e.getSource();
			lotterycompose com = LCM.get(JB.group.num);

			for (int i = 0; i < 49; i++) {
				com.numbtn[i].setBackground(C_cmnum);
				com.numbtn[i].setSelected(false);
			}

			randomselect(com, 6);
			com.STAT.setText(Integer.toString(com.numbtncount) + "個號碼");

		}
	}

	class SOMERANDOMAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			lotbtn JB = (lotbtn) e.getSource();
			lotterycompose com = LCM.get(JB.group.num);

			int numm = 6 - com.numbtncount;
			if (numm != 0) {
				randomselect(com, numm);
			}

		}
	}

	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Lottery frame = new Lottery();
					frame.setLocationRelativeTo(null);
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	void stArt() {
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 1029, 718);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);

		JPanel panel = new JPanel();
		panel.setPreferredSize(new Dimension(10, 60));
		panel.setBackground(SystemColor.menu);
		contentPane.add(panel, BorderLayout.NORTH);
		panel.setLayout(null);

		JLabel lblNewLabel_1 = new JLabel(
				"\u5927\u6A02\u900F\u5C0D\u734E\u7CFB\u7D71");
		lblNewLabel_1.setIconTextGap(1);
		lblNewLabel_1.setFont(new Font("標楷體", Font.BOLD, 25));
		lblNewLabel_1.setBounds(432, 1, 189, 76);
		panel.add(lblNewLabel_1);

		lblNewLabel = new JLabel("");
		lblNewLabel.setFont(new Font("微軟正黑體", Font.PLAIN, 25));
		lblNewLabel.setBounds(0, 1, 215, 25);
		panel.add(lblNewLabel);

		LBLCOUNT = new JLabel("現有選號數:");
		LBLCOUNT.setFont(new Font("微軟正黑體", Font.PLAIN, 24));
		LBLCOUNT.setBounds(772, 1, 231, 37);
		panel.add(LBLCOUNT);

		JPanel panel_1 = new JPanel();
		panel_1.setPreferredSize(new Dimension(10, 180));
		panel_1.setBackground(SystemColor.menu);
		contentPane.add(panel_1, BorderLayout.SOUTH);
		panel_1.setLayout(null);

		lblNewLabel_2 = new JLabel("樂透開獎號:");
		lblNewLabel_2.setOpaque(true);
		lblNewLabel_2.setBackground(SystemColor.text);
		lblNewLabel_2.setForeground(Color.DARK_GRAY);
		lblNewLabel_2.setFont(new Font("微軟正黑體", Font.PLAIN, 25));
		lblNewLabel_2.setBounds(296, 5, 384, 38);
		panel_1.add(lblNewLabel_2);

		JButton btnlets = new JButton("<html>let's<br>開獎!!</html>");
		btnlets.setToolTipText("開獎囉");
		btnlets.setFocusPainted(false);
		btnlets.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (!checkBox.isSelected())
					resetstatenum();

				Randomcom(7);
				Arrays.sort(randcompose, 0, 6);
				lblNewLabel_2.setText("<html>\u6A02\u900F\u958B\u734E\u865F:"
						+ Integer.toString(randcompose[0]) + ","
						+ Integer.toString(randcompose[1]) + ","
						+ Integer.toString(randcompose[2]) + ","
						+ Integer.toString(randcompose[3]) + ","
						+ Integer.toString(randcompose[4]) + ","
						+ Integer.toString(randcompose[5]) + ","
						+ "<font color=red>" + Integer.toString(randcompose[6])
						+ "</font>" + "</html>");

				for (lotterycompose a : LCM) {
					if (a.numbtncount == 6) {
						compareLot(a);
						count++;
					} else {
						a.STAT.setText("這組無效");
					}
				}

				wsta1.setText("頭獎:" + Long.toString(wincm[0]) + "組");
				wsta2.setText("貳獎:" + Long.toString(wincm[1]) + "組");
				wsta3.setText("參獎:" + Long.toString(wincm[2]) + "組");
				wsta4.setText("肆獎:" + Long.toString(wincm[3]) + "組");
				wsta5.setText("伍獎:" + Long.toString(wincm[4]) + "組");
				wsta6.setText("陸獎:" + Long.toString(wincm[5]) + "組");
				wsta7.setText("柒獎:" + Long.toString(wincm[6]) + "組");
				wsta8.setText("普獎:" + Long.toString(wincm[7]) + "組");

				totalwin = wincm[0] * WIN1 + wincm[1] * WIN2 + wincm[2] * WIN3
						+ wincm[3] * WIN4 + wincm[4] * WIN5 + wincm[5] * WIN6
						+ wincm[6] * WIN7 + wincm[7] * WIN7;
				long cost = count * 50;

				winstate.setText("<html>獎金:<br>NT$" + Long.toString(totalwin)
						+ "<br>總對獎組數:<br>" + Long.toString(count)
						+ "<br>花費:<br>NT$" + Long.toString(cost) + "</html>");

			}
		});
		btnlets.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		btnlets.setBackground(new Color(255, 228, 225));
		btnlets.setFont(new Font("標楷體", Font.BOLD, 25));
		btnlets.setBounds(10, 10, 133, 169);
		panel_1.add(btnlets);

		JLabel lblNewLabel_4 = new JLabel("\u60A8\u4E2D\u4E86:\r\n");
		lblNewLabel_4.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		lblNewLabel_4.setVerticalAlignment(SwingConstants.TOP);
		lblNewLabel_4.setBounds(296, 47, 78, 30);
		panel_1.add(lblNewLabel_4);

		titletrash titlerun = new titletrash(panel, lblNewLabel_1);
		
		JLabel lblNewLabel_3 = new JLabel("\u8F14\u52A9\u529F\u80FD");
		lblNewLabel_3.setOpaque(true);
		lblNewLabel_3.setBackground(Color.RED);
		lblNewLabel_3.setBounds(942, 45, 61, 15);
		panel.add(lblNewLabel_3);
		titlerun.start();

		wsta1 = new JLabel("頭獎:");
		wsta1.setVerticalAlignment(SwingConstants.TOP);
		wsta1.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta1.setBounds(384, 47, 186, 30);
		panel_1.add(wsta1);

		wsta2 = new JLabel("貳獎:");
		wsta2.setVerticalAlignment(SwingConstants.TOP);
		wsta2.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta2.setBounds(573, 47, 186, 30);
		panel_1.add(wsta2);

		wsta3 = new JLabel("參獎:");
		wsta3.setVerticalAlignment(SwingConstants.TOP);
		wsta3.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta3.setBounds(384, 80, 186, 30);
		panel_1.add(wsta3);

		wsta4 = new JLabel("肆獎:");
		wsta4.setVerticalAlignment(SwingConstants.TOP);
		wsta4.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta4.setBounds(573, 80, 186, 30);
		panel_1.add(wsta4);

		wsta5 = new JLabel("伍獎:");
		wsta5.setVerticalAlignment(SwingConstants.TOP);
		wsta5.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta5.setBounds(384, 114, 186, 30);
		panel_1.add(wsta5);

		wsta6 = new JLabel("陸獎:");
		wsta6.setVerticalAlignment(SwingConstants.TOP);
		wsta6.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta6.setBounds(573, 114, 186, 30);
		panel_1.add(wsta6);

		wsta7 = new JLabel("柒獎:");
		wsta7.setVerticalAlignment(SwingConstants.TOP);
		wsta7.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta7.setBounds(384, 149, 186, 30);
		panel_1.add(wsta7);

		wsta8 = new JLabel("普獎:");
		wsta8.setVerticalAlignment(SwingConstants.TOP);
		wsta8.setFont(new Font("微軟正黑體", Font.BOLD, 22));
		wsta8.setBounds(573, 149, 186, 30);
		panel_1.add(wsta8);

		winstate = new JLabel("\u734E\u91D1:");
		winstate.setHorizontalAlignment(SwingConstants.CENTER);
		winstate.setVerticalAlignment(SwingConstants.TOP);
		winstate.setOpaque(true);
		winstate.setBackground(SystemColor.text);
		winstate.setFont(new Font("微軟正黑體", Font.BOLD, 20));
		winstate.setBounds(767, 5, 236, 180);
		panel_1.add(winstate);

		JButton button_1 = new JButton("<html>\u8B93\u4F60\u5C0D\u5230<br>\u4E2D\u734E!<br>(\u53EF\u4E2D\u65B7)</html>");
		button_1.setToolTipText("");
		button_1.setFocusPainted(false);
		button_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (!checkBox.isSelected())
					resetstatenum();
				long star = wincm[comboBox.getSelectedIndex()];
				cstop = false;

				Thread thread2 = new Thread(new Runnable() {
					public void run() {
						int c = 0;
						while ((wincm[comboBox.getSelectedIndex()] == star)) {
							c = JOptionPane.showConfirmDialog(null,
									"兌獎中，請稍後....", "",
									JOptionPane.OK_CANCEL_OPTION);
							if (c == 2) {
								cstop = true;
								break;
							}
						}
					}
				});

				Thread thread3 = new Thread(new Runnable() {
					public void run() {
						boolean checked = false;

						int c = JOptionPane.showConfirmDialog(null,
								"這會執行很久，確定要使用嗎", "確認",
								JOptionPane.YES_NO_CANCEL_OPTION);

						for (lotterycompose com : LCM) {
							if (com.numbtncount == 6) {
								checked = true;
								break;
							}
						}

						if (checked && c == 0) {

							JOptionPane.showMessageDialog(null, "開始囉!");
							lblNewLabel.setText("開獎中，請等待");
							thread2.start();

							int round = 0;
							while ((wincm[comboBox.getSelectedIndex()] == star) && !cstop) {
								Randomcom(7);
								Arrays.sort(randcompose, 0, 6);
								lblNewLabel_2.setText(
										"<html>\u6A02\u900F\u958B\u734E\u865F:"
												+ Integer.toString(
														randcompose[0])
												+ ","
												+ Integer.toString(
														randcompose[1])
												+ ","
												+ Integer.toString(
														randcompose[2])
												+ ","
												+ Integer.toString(
														randcompose[3])
												+ ","
												+ Integer.toString(
														randcompose[4])
												+ ","
												+ Integer.toString(
														randcompose[5])
												+ "," + "<font color=red>"
												+ Integer.toString(
														randcompose[6])
												+ "</font>" + "</html>");

								for (lotterycompose a : LCM) {
									if (a.numbtncount == 6) {
										try {
											compareLot(a);
										} catch (Exception e) {
										}
										;
										count++;
									} else {
										a.STAT.setText("這組無效");
									}
								}

								round++;
							}

							lblNewLabel.setText("");

							wsta1.setText(
									"頭獎:" + Long.toString(wincm[0]) + "組");
							wsta2.setText(
									"貳獎:" + Long.toString(wincm[1]) + "組");
							wsta3.setText(
									"參獎:" + Long.toString(wincm[2]) + "組");
							wsta4.setText(
									"肆獎:" + Long.toString(wincm[3]) + "組");
							wsta5.setText(
									"伍獎:" + Long.toString(wincm[4]) + "組");
							wsta6.setText(
									"陸獎:" + Long.toString(wincm[5]) + "組");
							wsta7.setText(
									"柒獎:" + Long.toString(wincm[6]) + "組");
							wsta8.setText(
									"普獎:" + Long.toString(wincm[7]) + "組");
							JOptionPane.showMessageDialog(null,
									"開了" + Integer.toString(round) + "次獎");
							thread2.interrupt();

							totalwin = wincm[0] * WIN1 + wincm[1] * WIN2
									+ wincm[2] * WIN3 + wincm[3] * WIN4
									+ wincm[4] * WIN5 + wincm[5] * WIN6
									+ wincm[6] * WIN7 + wincm[7] * WIN7;

							long cost = count * 50;

							winstate.setText("<html>獎金:<br>NT$"
									+ Long.toString(totalwin) + "<br>總對獎組數:<br>"
									+ Long.toString(count) + "<br>花費:<br>NT$"
									+ Long.toString(cost) + "</html>");
						} else if (!checked) {
							JOptionPane.showMessageDialog(null, "沒有任何選號喔!");
						}
					}

				});
				thread3.start();

			}
		});
		button_1.setFont(new Font("標楷體", Font.BOLD, 25));
		button_1.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_1.setBackground(new Color(255, 228, 225));
		button_1.setBounds(153, 39, 133, 140);
		panel_1.add(button_1);
		
		comboBox = new JComboBox();
		comboBox.setModel(new DefaultComboBoxModel(new String[] {"\u982D\u734E", "\u8CB3\u734E", "\u53C3\u734E", "\u8086\u734E"}));
		comboBox.setSelectedIndex(0);
		comboBox.setBounds(153, 10, 133, 21);
		panel_1.add(comboBox);
		
		

		JPanel panel_2 = new JPanel();
		panel_2.setPreferredSize(new Dimension(70, 10));
		panel_2.setBackground(SystemColor.menu);
		contentPane.add(panel_2, BorderLayout.EAST);
		panel_2.setLayout(null);

		JButton btnnbsp_1 = new JButton("<html>上一筆<br>&nbsp中獎</html>");
		btnnbsp_1.setFocusPainted(false);
		btnnbsp_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				int a = scrollPane.getVerticalScrollBar().getValue();
				// System.out.println(a);
				a = a / 105;
				int b = a;
				// System.out.println(a);
				for (int i = a - 1; i > 0; i--) {
					if (LCM.get(i).win != 0) {
						a = i;
						break;
					}
				}
				if (a == b) {
					JOptionPane.showMessageDialog(null, "前面沒有囉~");
				}
				// System.out.println(a);

				scrollPane.getVerticalScrollBar().setValue(a * 105);

			}
		});
		btnnbsp_1.setPreferredSize(new Dimension(130, 50));
		btnnbsp_1.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		btnnbsp_1.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		btnnbsp_1.setBackground(Color.LIGHT_GRAY);
		btnnbsp_1.setBounds(0, 0, 70, 50);
		panel_2.add(btnnbsp_1);

		JButton btnnbsp_2 = new JButton("<html>下一筆<br>&nbsp中獎</html>");
		btnnbsp_2.setFocusPainted(false);
		btnnbsp_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int a = scrollPane.getVerticalScrollBar().getValue();
				// System.out.println(a);
				a = a / 105;
				int b = a;
				// System.out.println(a);
				for (int i = a + 1; i < LCM.size(); i++) {
					if (LCM.get(i).win != 0) {
						a = i;
						break;
					}
				}
				if (a == b) {
					JOptionPane.showMessageDialog(null, "後面沒有囉~");
				}
				// System.out.println(a);

				scrollPane.getVerticalScrollBar().setValue(a * 105);

			}
		});
		btnnbsp_2.setPreferredSize(new Dimension(130, 50));
		btnnbsp_2.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		btnnbsp_2.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		btnnbsp_2.setBackground(Color.LIGHT_GRAY);
		btnnbsp_2.setBounds(0, 50, 70, 50);
		panel_2.add(btnnbsp_2);

		JButton button_2 = new JButton("<html>下一筆<br>未完成</html>");
		button_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int a = scrollPane.getVerticalScrollBar().getValue();
				// System.out.println(a);
				a = a / 105;
				int b = a;
				// System.out.println(a);
				for (int i = a + 1; i < LCM.size(); i++) {
					if (LCM.get(i).numbtncount < 6) {
						a = i;
						break;
					}
				}
				if (a == b) {
					JOptionPane.showMessageDialog(null, "後面沒有囉~");
				}
				// System.out.println(a);

				scrollPane.getVerticalScrollBar().setValue(a * 105);
			}
		});
		button_2.setPreferredSize(new Dimension(130, 50));
		button_2.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		button_2.setFocusPainted(false);
		button_2.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_2.setBackground(Color.LIGHT_GRAY);
		button_2.setBounds(0, 159, 70, 50);
		panel_2.add(button_2);

		JButton button_3 = new JButton("<html>上一筆<br>未完成</html>");
		button_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int a = scrollPane.getVerticalScrollBar().getValue();
				// System.out.println(a);
				a = a / 105;
				int b = a;
				// System.out.println(a);
				for (int i = a - 1; i > 0; i--) {
					if (LCM.get(i).numbtncount < 6) {
						a = i;
						break;
					}
				}
				if (a == b) {
					JOptionPane.showMessageDialog(null, "前面沒有囉~");
				}
				// System.out.println(a);

				scrollPane.getVerticalScrollBar().setValue(a * 105);
			}
		});
		button_3.setPreferredSize(new Dimension(130, 50));
		button_3.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		button_3.setFocusPainted(false);
		button_3.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_3.setBackground(Color.LIGHT_GRAY);
		button_3.setBounds(0, 110, 70, 50);
		panel_2.add(button_3);

		JButton button_6 = new JButton("<html>上一筆</html>");
		button_6.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int a = scrollPane.getVerticalScrollBar().getValue();
				scrollPane.getVerticalScrollBar().setValue(a - 105);

			}
		});
		button_6.setPreferredSize(new Dimension(130, 50));
		button_6.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		button_6.setFocusPainted(false);
		button_6.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_6.setBackground(Color.LIGHT_GRAY);
		button_6.setBounds(0, 219, 70, 50);
		panel_2.add(button_6);

		JButton button_7 = new JButton("<html>下一筆</html>");
		button_7.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int a = scrollPane.getVerticalScrollBar().getValue();
				scrollPane.getVerticalScrollBar().setValue(a + 105);
			}
		});
		button_7.setPreferredSize(new Dimension(130, 50));
		button_7.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		button_7.setFocusPainted(false);
		button_7.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_7.setBackground(Color.LIGHT_GRAY);
		button_7.setBounds(0, 266, 70, 50);
		panel_2.add(button_7);

		JButton btnnbspnbspnbsp = new JButton(
				"<html>未完選號<br>&nbsp&nbsp&nbsp刪除</html>");
		btnnbspnbspnbsp.setBounds(0, 326, 70, 50);
		panel_2.add(btnnbspnbspnbsp);
		btnnbspnbspnbsp.setFocusPainted(false);
		btnnbspnbspnbsp.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (!NewCIng) {
					ListIterator a = LCM.listIterator();
					int b = LCM.size() - 1;

					while (a.hasNext()) {
						a.next();
					}

					while (a.hasPrevious()) {
						lotterycompose lc = (lotterycompose) a.previous();
						if (lc.numbtncount < 6) {
							a.remove();
							FLOWPPANEL.remove(b);
						}
						b--;
					}
					LBLCOUNT.setText("現有選號數:" + Integer.toString(LCM.size()));
					FLOWPPANEL.setPreferredSize(
							new Dimension(800, 5 + 105 * (LCM.size())));

					FLOWPPANEL.validate();
					FLOWPPANEL.updateUI();
					int i = 0;
					for (lotterycompose cm : LCM) {

						cm.group.num = i;
						i++;
					}

				}
			}
		});
		btnnbspnbspnbsp.setPreferredSize(new Dimension(130, 50));
		btnnbspnbspnbsp.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		btnnbspnbspnbsp.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		btnnbspnbspnbsp.setBackground(Color.LIGHT_GRAY);
		
				JButton btnnbsp_3 = new JButton("<html>&nbsp全部<br>隨機選</html>");
				btnnbsp_3.setBounds(0, 378, 70, 50);
				panel_2.add(btnnbsp_3);
				btnnbsp_3.setFocusPainted(false);
				btnnbsp_3.addActionListener(new ActionListener() {
					public void actionPerformed(ActionEvent e) {
						for (int cm = 0; cm < LCM.size(); cm++) {
							lotterycompose com = LCM.get(cm);
							for (int i = 0; i < 49; i++) {
								com.numbtn[i].setBackground(C_cmnum);
								com.numbtn[i].setSelected(false);
							}

							randomselect(com, 6);
						}

					}
				});
				btnnbsp_3.setPreferredSize(new Dimension(130, 50));
				btnnbsp_3.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
				btnnbsp_3.setBorder(new BevelBorder(BevelBorder.LOWERED,
						new Color(0, 0, 0), new Color(0, 0, 0), null, null));
				btnnbsp_3.setBackground(Color.LIGHT_GRAY);

		JPanel panel_3 = new JPanel();
		panel_3.setPreferredSize(new Dimension(110, 10));
		panel_3.setBackground(SystemColor.menu);
		contentPane.add(panel_3, BorderLayout.WEST);
		panel_3.setLayout(null);

		JButton btnNewButton_1 = new JButton(
				"<html>\u65B0\u589E\u4E00\u7D44<br>\u7A7A\u767D\u9078\u865F</html>");
		btnNewButton_1.setToolTipText("新增一組空白選號，最多1000組選號");
		btnNewButton_1.setFocusPainted(false);
		btnNewButton_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (NewCIng) {
					JOptionPane.showMessageDialog(null, "新增號碼組中...");
				} else if (LCM.size() < themax) {
					newlotterycompose();
					LBLCOUNT.setText("現有選號數:" + Integer.toString(LCM.size()));
				} else {
					JOptionPane.showMessageDialog(null,
							"overmax:" + Integer.toString(themax));
				}
			}
		});
		btnNewButton_1.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		btnNewButton_1.setBackground(Color.LIGHT_GRAY);
		btnNewButton_1.setBounds(7, 0, 97, 42);
		btnNewButton_1.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		btnNewButton_1.setPreferredSize(new Dimension(130, 50));
		panel_3.add(btnNewButton_1);

		JPanel panel_6 = new JPanel();
		panel_6.setBackground(new Color(220, 220, 220));
		panel_6.setBounds(7, 41, 97, 76);
		panel_3.add(panel_6);
		panel_6.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));

		JLabel label = new JLabel(
				"\u65B0\u589E\u591A\u7D44\u7A7A\u767D\u9078\u865F");
		label.setFont(new Font("微軟正黑體", Font.BOLD, 11));
		panel_6.add(label);

		textField = new JTextField();
		panel_6.add(textField);
		textField.setColumns(5);

		JLabel label_1 = new JLabel("\u7D44");
		label_1.setFont(new Font("微軟正黑體", Font.BOLD, 12));
		panel_6.add(label_1);

		JButton button_4 = new JButton("\u65B0\u589E");
		button_4.setToolTipText("新增多組空白選號，最多1000組選號");
		button_4.setFocusPainted(false);
		button_4.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				int round = 0;
				try {
					round = Integer.parseInt(textField.getText());
				} catch (NumberFormatException e) {
					JOptionPane.showMessageDialog(null, "please enter integer");
				}
				if (NewCIng) {
					JOptionPane.showMessageDialog(null, "新增號碼組中...");
				} else if (LCM.size() + round <= themax) {
					NewCIng = true;
					btnlets.setEnabled(false);
					button_1.setEnabled(false);
					int round2 = round;

					Thread thread3 = new Thread(new Runnable() {
						public void run() {
							for (int i = 0; i < round2; i++) {
								newlotterycompose();
								LBLCOUNT.setText("現有選號數:"
										+ Integer.toString(LCM.size()));
							}
							NewCIng = false;
							btnlets.setEnabled(true);
							button_1.setEnabled(true);
						}
					});
					thread3.start();

				} else {
					JOptionPane.showMessageDialog(null,
							"overmax:" + Integer.toString(themax));
				}

			}
		});
		button_4.setBackground(Color.LIGHT_GRAY);
		button_4.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_4.setFont(new Font("微軟正黑體", Font.BOLD, 12));
		panel_6.add(button_4);

		JButton button_5 = new JButton(
				"<html>\u65B0\u589E\u4E00\u7D44<br>\u96A8\u6A5F\u9078\u865F</html>");
		button_5.setToolTipText("新增一組選號，並幫你選好號碼，最多1000組選號");
		button_5.setFocusPainted(false);
		button_5.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (NewCIng) {
					JOptionPane.showMessageDialog(null, "新增號碼組中...");
				} else if (LCM.size() < themax) {
					newlotterycompose();
					LBLCOUNT.setText("現有選號數:" + Integer.toString(LCM.size()));
					lotterycompose com = LCM.getLast();
					randomselect(com, 6);
				} else {
					JOptionPane.showMessageDialog(null,
							"overmax:" + Integer.toString(themax));
				}

			}
		});
		button_5.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_5.setPreferredSize(new Dimension(130, 50));
		button_5.setFont(new Font("微軟正黑體", Font.PLAIN, 16));
		button_5.setBackground(Color.LIGHT_GRAY);
		button_5.setBounds(7, 127, 97, 42);
		panel_3.add(button_5);

		JPanel panel_7 = new JPanel();
		panel_7.setBackground(new Color(220, 220, 220));
		panel_7.setBounds(7, 168, 97, 76);
		panel_3.add(panel_7);
		panel_7.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));

		JLabel label_2 = new JLabel(
				"\u65B0\u589E\u591A\u7D44\u96A8\u6A5F\u9078\u865F");
		label_2.setFont(new Font("微軟正黑體", Font.BOLD, 11));
		panel_7.add(label_2);

		textField_1 = new JTextField();
		textField_1.setColumns(5);
		panel_7.add(textField_1);

		JLabel label_3 = new JLabel("\u7D44");
		label_3.setFont(new Font("微軟正黑體", Font.BOLD, 12));
		panel_7.add(label_3);

		JButton button_20 = new JButton("\u65B0\u589E");
		button_20.setToolTipText("新增多組選號，並幫你選好號碼，最多1000組選號");
		button_20.setFocusPainted(false);
		button_20.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int round = 0;
				try {
					round = Integer.parseInt(textField_1.getText());
				} catch (NumberFormatException ee1) {
					JOptionPane.showMessageDialog(null, "please enter integer");
				}
				if (NewCIng) {
					JOptionPane.showMessageDialog(null, "新增號碼組中...");
				} else if ((LCM.size() + round <= themax) && !NewCIng) {
					NewCIng = true;
					btnlets.setEnabled(false);
					button_1.setEnabled(false);
					int round2 = round;
					Thread thread3 = new Thread(new Runnable() {
						public void run() {
							for (int i = 0; i < round2; i++) {
								newlotterycompose();
								lotterycompose com = LCM.getLast();
								randomselect(com, 6);
							}
							LBLCOUNT.setText(
									"現有選號數:" + Integer.toString(LCM.size()));
							NewCIng = false;
							btnlets.setEnabled(true);
							button_1.setEnabled(true);
						}
					});
					thread3.start();

				} else {
					JOptionPane.showMessageDialog(null,
							"overmax:" + Integer.toString(themax));
				}

			}
		});
		button_20.setBackground(Color.LIGHT_GRAY);
		button_20.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button_20.setFont(new Font("微軟正黑體", Font.BOLD, 12));
		panel_7.add(button_20);

		JButton button = new JButton("<html>\r\n選號<br>\r\n補齊\r\n</html>");
		button.setToolTipText("沒有選好的全部幫你補上");
		button.setFocusPainted(false);
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				for (int i = 0; i < LCM.size(); i++) {
					lotterycompose com = LCM.get(i);
					int numm = 6 - com.numbtncount;
					if (numm == 0) {
						continue;
					}
					randomselect(com, numm);
				}
			}
		});
		button.setFont(new Font("標楷體", Font.BOLD, 25));
		button.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		button.setBackground(new Color(255, 228, 225));
		button.setBounds(7, 254, 100, 64);
		panel_3.add(button);

		JButton btnnbsp = new JButton("<html>\r\n選號<br>\r\n清空\r\n</html>");
		btnnbsp.setToolTipText("把全部的號碼組，無論有無選號都清空");
		btnnbsp.setFocusPainted(false);
		btnnbsp.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (!NewCIng) {

					FLOWPPANEL.removeAll();
					LCM.clear();
					LBLCOUNT.setText("現有選號數:" + Integer.toString(LCM.size()));
					FLOWPPANEL.setPreferredSize(
							new Dimension(800, 5 + 105 * (LCM.size())));
					FLOWPPANEL.validate();
					FLOWPPANEL.updateUI();
				}
			}
		});
		btnnbsp.setFont(new Font("標楷體", Font.BOLD, 25));
		btnnbsp.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		btnnbsp.setBackground(new Color(255, 228, 225));
		btnnbsp.setBounds(7, 328, 100, 64);
		panel_3.add(btnnbsp);

		checkBox = new JCheckBox("中獎累計");
		checkBox.setToolTipText("可以累計你投了多少注，中多少次獎，得到多少獎金。");
		checkBox.setFont(new Font("微軟正黑體", Font.BOLD, 16));
		checkBox.setBounds(7, 416, 97, 23);
		panel_3.add(checkBox);

		scrollPane = new JScrollPane();
		contentPane.add(scrollPane, BorderLayout.CENTER);
		FLOWPPANEL.setToolTipText("");

		FLOWPPANEL.setPreferredSize(new Dimension(800, 200));
		FLOWPPANEL.setMaximumSize(new Dimension(800, 32767));
		FLOWPPANEL.setBorder(null);
		scrollPane.setViewportView(FLOWPPANEL);
		FlowLayout fl_FLOWPPANEL = new FlowLayout(FlowLayout.LEFT, 5, 5);
		FLOWPPANEL.setLayout(fl_FLOWPPANEL);

	}

	void compareLot(lotterycompose cm) {
		int hit = 0;
		boolean sphit = false;

		for (int i = 0; i < 6; i++) {
			if (cm.numbtn[randcompose[i] - 1].isSelected()) {
				hit++;
			}
		}

		if (cm.numbtn[randcompose[6] - 1].isSelected()) {
			sphit = true;
		}
		switch (hit) {
		case 6:
			cm.STAT.setText("<html>恭喜您中了<br>頭獎!!!</html>");
			wincm[0]++;
			cm.win = 1;
			break;
		case 5:
			if (sphit) {
				cm.STAT.setText("<html>恭喜您中了<br>貳獎!!!</html>");
				wincm[1]++;
				cm.win = 2;
			} else {
				cm.STAT.setText("<html>恭喜您中了<br>參獎!!!</html>");
				wincm[2]++;
				cm.win = 3;
			}
			break;
		case 4:
			if (sphit) {
				cm.STAT.setText("<html>恭喜您中了<br>肆獎!!!</html>");
				wincm[3]++;
				cm.win = 4;
			} else {
				cm.STAT.setText("<html>您中了<br>伍獎!!!</html>");
				wincm[4]++;
				cm.win = 5;
			}
			break;
		case 3:
			if (sphit) {
				cm.STAT.setText("<html>您中了<br>陸獎!!!</html>");
				wincm[5]++;
				cm.win = 6;
			} else {
				cm.STAT.setText("<html>您中了<br>普獎!!!</html>");
				wincm[7]++;
				cm.win = 8;
			}
			break;
		case 2:
			if (sphit) {
				cm.STAT.setText("<html>您中了<br>柒獎!!!</html>");
				wincm[6]++;
				cm.win = 7;
			} else {
				cm.STAT.setText("(Q_Q)");
				wincm[8]++;
				cm.win = 0;
			}
			break;
		default:
			cm.STAT.setText("(Q_Q)");
			wincm[8]++;
			cm.win = 0;
			break;
		}
	}

	void newlotterycompose() {
		lotterycompose lc = new lotterycompose();

		lc.group = new group(LCM.size());
		// FLOWPPANEL
		lc.ComposePanel = new JPanel();
		lc.ComposePanel.setBackground(C_cmpanel);
		lc.ComposePanel.setPreferredSize(new Dimension(800, 100));
		FLOWPPANEL.add(lc.ComposePanel);
		lc.ComposePanel.setLayout(null);

		for (int i = 0; i <= 2; i++) {
			for (int j = 1; j <= 17; j++) {
				int NB = i * 17 + j;
				if (NB <= 49) {

					lotbtn JB = new lotbtn();

					JB.setPreferredSize(new Dimension(30, 30));
					JB.setFont(new Font("微軟正黑體", Font.BOLD, 18));
					JB.setBorder(new BevelBorder(BevelBorder.LOWERED,
							new Color(0, 0, 0), new Color(0, 0, 0), null,
							null));
					JB.setBackground(C_cmnum);
					JB.setFocusPainted(false);
					JB.setBounds(35 * j, 33 * i, 30, 30);
					JB.setText(btntxt[NB - 1]);
					JB.addActionListener(new NumberBTNAction());
					JB.group = lc.group;
					JB.lotterycompose=lc;
					lc.ComposePanel.add(JB);

					// System.out.println(NB);
					lc.numbtn[NB - 1] = JB;
					// lc.numbtn.add(JB);
				}
			}
		}

		lc.del = new lotbtn();
		lc.del.setBackground(C_cmdel);
		lc.del.setBounds(0, 5, 30, 90);
		lc.del.setFocusPainted(false);
		lc.del.setPreferredSize(new Dimension(30, 90));
		lc.del.setFont(new Font("微軟正黑體", Font.BOLD, 16));
		lc.del.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));
		lc.del.group = lc.group;
		lc.del.setText("X");
		lc.del.addActionListener(new DELBTNAction());
		lc.ComposePanel.add(lc.del);

		lc.random = new lotbtn();
		lc.random.setBounds(630, 5, 90, 43);
		lc.random.setBackground(C_cmrandom);
		lc.random.setFocusPainted(false);
		lc.random.group = lc.group;
		lc.random.setText("<html>\u96A8\u6A5F<br>\u9078\u865F</html>");
		lc.random.setPreferredSize(new Dimension(90, 90));
		lc.random.setFont(new Font("微軟正黑體", Font.BOLD, 16));
		lc.random.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		lc.random.addActionListener(new RANDOMAction());
		lc.ComposePanel.add(lc.random);

		lc.somerandom = new lotbtn();
		lc.somerandom.setBounds(630, 52, 90, 43);
		lc.somerandom.setBackground(C_cmrandom);
		lc.somerandom.setFocusPainted(false);
		lc.somerandom.group = lc.group;
		lc.somerandom.setText("<html>\u90E8\u5206<br>\u9078\u865F</html>");
		lc.somerandom.setPreferredSize(new Dimension(90, 90));
		lc.somerandom.setFont(new Font("微軟正黑體", Font.BOLD, 16));
		lc.somerandom.setBorder(new BevelBorder(BevelBorder.LOWERED,
				new Color(0, 0, 0), new Color(0, 0, 0), null, null));
		lc.somerandom.addActionListener(new SOMERANDOMAction());
		lc.ComposePanel.add(lc.somerandom);

		lc.STAT = new JLabel();
		lc.STAT.setBounds(725, 5, 65, 90);
		lc.STAT.setHorizontalAlignment(SwingConstants.CENTER);
		lc.STAT.setVerticalAlignment(SwingConstants.CENTER);
		lc.STAT.setOpaque(true);
		lc.STAT.setFont(new Font("微軟正黑體", Font.BOLD, 15));
		lc.STAT.setBackground(C_cmstate);
		lc.ComposePanel.add(lc.STAT);

		LBLCOUNT.setText("現有選號數:" + Integer.toString(LCM.size()));

		LCM.add(lc);

		FLOWPPANEL.setPreferredSize(new Dimension(800, 5 + 105 * (LCM.size())));

		FLOWPPANEL.validate();
		FLOWPPANEL.updateUI();
	}

	void Randomcom(int max) {
		randcompose[0] = (int) (Math.random() * 49) + 1;
		for (int i = 1; i < max; i++) {
			randcompose[i] = (int) (Math.random() * 49) + 1;
			for (int j = 0; j < i; j++) {
				if (randcompose[i] == randcompose[j]) {
					i--;
					break;
				}
			}
		}
		String ssss = "";
		for (int x = 0; x < max; x++) {
			ssss += Integer.toString(randcompose[x]) + ",";
		}
		// System.out.println(ssss);
	}

	void randomselect(lotterycompose com, int num) {
		for (int i = 0; i < num; i++) {
			Randomcom(1);
			if (com.numbtn[randcompose[0] - 1].isSelected()) {
				i--;
			} else {
				com.numbtn[randcompose[0] - 1].setBackground(C_cmnumselet);
				;
				com.numbtn[randcompose[0] - 1].setSelected(true);
			}

		}

		com.numbtncount = 6;
		com.STAT.setText(Integer.toString(com.numbtncount) + "個號碼");
		com.win = 0;
	}

	void resetstatenum() {

		wincm[0] = 0;
		wincm[1] = 0;
		wincm[2] = 0;
		wincm[3] = 0;
		wincm[4] = 0;
		wincm[5] = 0;
		wincm[6] = 0;
		wincm[7] = 0;
		wincm[8] = 0;
		totalwin = 0;
		count = 0;
	}

	void resetstatetext() {
		winstate.setText("");
	}

	/*
	 * void delsame() { LinkedList<Integer> g=new LinkedList<>();
	 * TreeSet<Integer> al=new TreeSet<>(); TreeSet<Integer> needdelet=new
	 * TreeSet<>(); Iterator LCMit=LCM.iterator(); int i=-1;
	 * while(LCMit.hasNext()) { i++; lotterycompose C= LCMit.next();
	 * TreeSet<Integer> aIn=new TreeSet<>(); int sn=-1; if(al.contains(i))
	 * {continue;}
	 * 
	 * 
	 * 
	 * for(int j=0;j<49;j++) { if(C.numbtn[j].isSelected()) { sn=j; break; } }
	 * 
	 * for(int k=i+1;k<LCM.size();k++) { if(LCM.get(k).numbtn[sn].isSelected())
	 * { al.add(k); aIn.add(k); } } needdelet.addAll(delsame2(C,1,sn,aIn));
	 * 
	 * 
	 * }
	 * 
	 * System.out.println(needdelet); }
	 * 
	 * TreeSet<Integer> delsame2(lotterycompose C,int bt,int sn,TreeSet<Integer>
	 * cm) { for(int i=sn+1;i<49;i++) { if(C.numbtn[i].isSelected()) { sn=i;
	 * break; } }
	 * 
	 * for(int k:cm) { if(!LCM.get(k).numbtn[sn].isSelected()) { cm.remove(k); }
	 * }
	 * 
	 * if(bt<6) { delsame2(C,bt+1,sn,cm); }
	 * 
	 * return cm;
	 * 
	 * 
	 * }
	 */

	public Lottery() {

		for (int i = 0; i < 49; i++) {
			btntxt[i] = Integer.toString(i + 1);
		}

		setTitle("\u5927\u6A02\u900F\u5C0D\u734E\u7CFB\u7D71");
		stArt();

		FLOWPPANEL.removeAll();

	}
}

class lotterycompose {
	JPanel ComposePanel;
	// ArrayList<JButton>numbtn =new ArrayList<JButton>();
	lotbtn[] numbtn = new lotbtn[49];
	int numbtncount = 0;
	// int[] COMP = new int[6] ;
	lotbtn del;
	lotbtn random;
	lotbtn somerandom;
	JLabel STAT;
	int win = 0;
	group group;

}

class lotbtn extends JButton {
	lotterycompose lotterycompose;
	group group;
}

class group {
	int num;

	group(int a) {
		num = a;
	}
}

class titletrash extends Thread {

	JPanel jP;
	JLabel LBL;

	titletrash(JPanel jP, JLabel LBL) {
		this.jP = jP;
		this.LBL = LBL;
	}

	public void run() {
		int i = 0;
		int x = 451;
		int y = 1;
		int f = 20;
		boolean yturn = true;
		boolean xturn = true;
		boolean fturn = true;
		while (true) {
			try {
				sleep(100);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			i = i % 5;
			i++;

			if (xturn) {
				x += 3;
				if (x > 551) {
					xturn = false;
				}

			} else {
				x -= 3;
				if (x < 301) {
					xturn = true;
				}
			}

			if (yturn) {
				y += 3;
				if (y > 25) {
					yturn = false;
				}

			} else {
				y -= 3;
				if (y < -30) {
					yturn = true;
				}
			}

			if (fturn) {
				f++;
				if (f > 25) {
					fturn = false;
				}

			} else {
				f--;
				if (f < 14) {
					fturn = true;
				}
			}

			LBL.setBounds(x, y, 189, 76);

			LBL.setFont(new Font("標楷體", Font.BOLD, f));

			switch (i) {
			case 0:
				LBL.setForeground(new Color(150, 0, 0));
				break;
			case 1:
				LBL.setForeground(Color.black);
				break;
			case 2:
				LBL.setForeground(new Color(50, 50, 50));
				break;
			case 3:
				LBL.setForeground(new Color(0, 00, 150));
				break;
			case 4:
				LBL.setForeground(Color.darkGray);
				break;
			case 5:
				LBL.setForeground(Color.gray);
				break;

			default:
				break;
			}

			jP.validate();
			jP.updateUI();
		}
	}
}
