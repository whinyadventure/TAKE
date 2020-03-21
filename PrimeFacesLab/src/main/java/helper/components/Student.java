/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helper.components;

/**
 *
 * @author mizer
 */
public class Student {
    private String fname;
    private String lname;
    private Float avg;  
    
    public Student(String name, String surname, Float average) {
        fname = name;
        lname = surname;
        avg = average;
    }

    /**
     * @return the fname
     */
    public String getFname() {
        return fname;
    }

    /**
     * @param fname the fname to set
     */
    public void setFname(String fname) {
        this.fname = fname;
    }

    /**
     * @return the lname
     */
    public String getLname() {
        return lname;
    }

    /**
     * @param lname the lname to set
     */
    public void setLname(String lname) {
        this.lname = lname;
    }

    /**
     * @return the avg
     */
    public Float getAvg() {
        return avg;
    }

    /**
     * @param avg the avg to set
     */
    public void setAvg(Float avg) {
        this.avg = avg;
    }
}

