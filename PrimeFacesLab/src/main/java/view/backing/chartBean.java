/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view.backing;

import static java.lang.Math.cos;
import static java.lang.Math.sin;
import javax.inject.Named;
import javax.enterprise.context.RequestScoped;
import org.primefaces.model.chart.Axis;
import org.primefaces.model.chart.AxisType;
import org.primefaces.model.chart.LineChartModel;
import org.primefaces.model.chart.LineChartSeries;

/**
 *
 * @author mizer
 */
@Named(value = "chartBean")
@RequestScoped
public class chartBean {
    
    private LineChartModel model;

    /**
     * Creates a new instance of chartBean
     */
    public chartBean() {
        model = new LineChartModel();
        
        LineChartSeries series1 = new LineChartSeries();
        series1.setLabel("Sine");
        
        for(Integer i=0; i <= 360; i+=10){
            series1.set(i, sin( Math.toRadians(i)));
        }
    
        LineChartSeries series2 = new LineChartSeries();
        series2.setLabel("Cosine");
        
        for(Integer i=0; i <= 360; i+=10){
            series2.set(i, cos( Math.toRadians(i)));
        }

        model.addSeries(series1);
        model.addSeries(series2);
        model.setTitle("Sine & Cosine <0;360>");
        model.setLegendPosition("e");
        model.setZoom(true);
        
        Axis xAxis = model.getAxis(AxisType.X);
        xAxis.setMin(0);
        xAxis.setMax(360);
        xAxis.setTickInterval("10");
        
        Axis yAxis = model.getAxis(AxisType.Y);
        yAxis.setMin(-1);
        yAxis.setMax(1);
    }

    /**
     * @return the model
     */
    public LineChartModel getModel() {
        return model;
    }
    
}
