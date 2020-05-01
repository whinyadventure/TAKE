/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import org.primefaces.json.JSONArray;
import org.primefaces.json.JSONObject;

/**
 *
 * @author mizer
 */
public class Main {
    
    public static void main(String[] args) {
        
        Client client = ClientBuilder.newClient();
        
        String count = client.target("http://localhost:8080/Complaints/resources/complaints/count")
            .request(MediaType.TEXT_PLAIN)
            .get(String.class);

        System.out.println("Count: " + count);
        
        String all = client.target("http://localhost:8080/Complaints/resources/complaints")
                .request(MediaType.APPLICATION_JSON)
                .get(String.class);

        System.out.println("All complaints:" + all);
        
        JSONArray arr = new JSONArray(all);
        JSONObject obj = null;
        
        String id = "";
        for(int i=0; i < arr.length(); i++) {
            obj = arr.getJSONObject(i);
            
            if(obj.getString("status").equals("open")){
                id = obj.get("id").toString();
                
                String first_open = client.target("http://localhost:8080/Complaints/resources/complaints/" + id)
                    .request(MediaType.APPLICATION_JSON)
                    .get(String.class);
            
                System.out.println("First open: " + first_open);
                
                Complaint complaint = new Complaint(new JSONObject(first_open));
                complaint.setStatus("closed");
                
                System.out.println("nyny " + complaint.getStatus());
                
                client.target("http://localhost:8080/Complaints/resources/complaints/" + id)
                    .request()
                    .put(Entity.json(complaint));
                
                break;
            }
        }
        
        String all_open = client.target("http://localhost:8080/Complaints/resources/complaints?status=open")
        .request(MediaType.APPLICATION_JSON)
        .get(String.class);
        
        System.out.println("All open complaints:" + all_open);
        
        client.close(); 
        
    }
    
}
