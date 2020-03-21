/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view.backing;

import javax.enterprise.context.RequestScoped;
import javax.faces.application.FacesMessage;
import javax.faces.context.FacesContext;
import javax.inject.Named;

/**
 *
 * @author mizer
 */
@Named(value = "sumBean")
@RequestScoped
public class sumBean {
    
    private Integer el_1;
    private Integer el_2;
    private Integer result;

    /**
     * Creates a new instance of sumBean
     */
    public sumBean() {
    }
    
    public void calculate() {
        result = el_1 + el_2;
        
        String op = el_1.toString() + " + " + el_2.toString() + " = " + result.toString();
        
        FacesContext context = FacesContext.getCurrentInstance();
        FacesMessage msg = new FacesMessage(op);
        context.addMessage("growl", msg);
        
    }
    
    public String getCurrentDateTime(){
        return new java.util.Date().toString();
    }

    /**
     * @return the el_1
     */
    public Integer getEl_1() {
        return el_1;
    }

    /**
     * @param el_1 the el_1 to set
     */
    public void setEl_1(Integer el_1) {
        this.el_1 = el_1;
    }

    /**
     * @return the el_2
     */
    public Integer getEl_2() {
        return el_2;
    }

    /**
     * @param el_2 the el_2 to set
     */
    public void setEl_2(Integer el_2) {
        this.el_2 = el_2;
    }

    /**
     * @return the result
     */
    public Integer getResult() {
        return result;
    }

    /**
     * @param result the result to set
     */
    public void setResult(Integer result) {
        this.result = result;
    }
    
}
