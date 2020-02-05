import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { EmailRequest } from "../models/EmailRequest";
import { EMAIL_API } from "../shared/constants";
import { SendEmailResponse } from "../models/SendEmailResponse";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class EmailService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  sendEmail(emailRequest: EmailRequest): Observable<SendEmailResponse> {
    let headers: HttpHeaders = new HttpHeaders();
    headers = headers.append("Accept", "application/json");
    headers = headers.append("Content-Type", "application/json");
    //let url = "http://localhost:63407/api/email";
    let url = `${this.baseUrl}${EMAIL_API}`;
    return this.http.post<SendEmailResponse>(url, emailRequest, { headers });
  }
}
