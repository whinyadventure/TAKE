/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package req.backing;

import java.time.LocalDate;
import java.util.List;
import javax.inject.Named;
import javax.enterprise.context.RequestScoped;
import javax.faces.component.html.HtmlDataTable;
import javax.inject.Inject;
import javax.validation.constraints.Size;
import req.entities.Request;
import req.facade.RequestFacadeLocal;

/**
 *
 * @author mizer
 */
@Named(value = "requestsList")
@RequestScoped
public class RequestsList {

    @Inject
    private RequestFacadeLocal requestFacade;
    
    @Size(min = 3, max = 60, message = "{request.size}")
    private String newRequest;
    
    private HtmlDataTable requestsDataTable;
    
    
    public RequestsList() {}  
    
    public List<Request> getAllRequests() {
        return requestFacade.findAll();
    }

    public String getNewRequest() {
        return newRequest;
    }

    public void setNewRequest(String newRequest) {
        this.newRequest = newRequest;
    }
    
    public HtmlDataTable getRequestsDataTable() {
        return requestsDataTable;
    }

    public void setRequestsDataTable(HtmlDataTable requestsDataTable) {
        this.requestsDataTable = requestsDataTable;
    }
    
    public String addRequest() {
        Request req = new Request();
        req.setRequestDate(LocalDate.now());
        req.setRequestText(this.newRequest);
        this.requestFacade.create(req);
        
        return null;
    }
    
     public String deleteRequest() {
        Request req = (Request) getRequestsDataTable().getRowData();
        this.requestFacade.remove(req);
        
        return null;
    }

}
