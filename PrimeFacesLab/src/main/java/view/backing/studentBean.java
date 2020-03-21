/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view.backing;

import java.io.Serializable;
import javax.inject.Named;
import javax.enterprise.context.SessionScoped;
import java.util.List;

import helper.components.Student;
import java.util.ArrayList;
/**
 *
 * @author mizer
 */
@Named(value = "studentBean")
@SessionScoped
public class studentBean implements Serializable {
    
    
    private String first_name;
    private String last_name;
    private Float avg;
    
    private List<Student> students = new ArrayList<>();

    /**
     * Creates a new instance of studentBean
     */
    public studentBean() {
    }
    
    public void addStudent() {
        students.add(new Student(first_name, last_name, avg));
    }

    /**
     * @return the students
     */
    public List<Student> getStudents() {
        return students;
    }

    /**
     * @param students the students to set
     */
    public void setStudents(List<Student> students) {
        this.students = students;
    }

    /**
     * @return the first_name
     */
    public String getFirst_name() {
        return first_name;
    }

    /**
     * @param first_name the first_name to set
     */
    public void setFirst_name(String first_name) {
        this.first_name = first_name;
    }

    /**
     * @return the last_name
     */
    public String getLast_name() {
        return last_name;
    }

    /**
     * @param last_name the last_name to set
     */
    public void setLast_name(String last_name) {
        this.last_name = last_name;
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
