package shmelev.visualTest;
import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class App extends JPanel implements  ActionListener {

    JButton b1, b2, b3;

    public App() {
        b1 = new JButton("Выключить");
        b1.setActionCommand("выключить");
        b2 = new JButton("Средняя");
        b3 = new JButton("Включить");
        b3.setActionCommand("включить");
        b3.setEnabled(false);
        add(b1);
        add(b2);
        add(b3);

        b1.addActionListener(this);
        b2.addActionListener(ea->{
                JOptionPane.showMessageDialog(null, "Средняя");
        });
        b3.addActionListener(this);
    }

    private static void showUI() {
        JFrame frame = new JFrame("ButtonDemo");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        App newContentPane = new App();
        frame.setContentPane(newContentPane);
        frame.pack();
        frame.setVisible(true);

    }
    public static void main(String[] args) {
        javax.swing.SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                showUI();
            }
        });
    }

    @Override
    public void actionPerformed(ActionEvent e)
    {
        if("выключить".equals(e.getActionCommand())){
            b1.setEnabled(false);
            b2.setEnabled(false);
            b3.setEnabled(true);
        } else {
            b1.setEnabled(true);
            b2.setEnabled(true);
            b3.setEnabled(false);
        }
    }
}