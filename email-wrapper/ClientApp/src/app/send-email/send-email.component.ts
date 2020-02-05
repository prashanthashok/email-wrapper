import { Component, OnInit, Inject, Input } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { EmailRequest } from "../models/EmailRequest";
import { EmailService } from "../services/email.service";
import { Observable } from "rxjs";
import { SendEmailResponse } from "../models/SendEmailResponse";

@Component({
  selector: "app-send-email",
  templateUrl: "./send-email.component.html",
  styleUrls: ["./send-email.component.css"]
})
export class SendEmailComponent implements OnInit {
  emailRequest: EmailRequest;
  emailResponse$: Observable<SendEmailResponse>;
  emailResponse: SendEmailResponse;
  constructor(private emailService: EmailService) {}

  ngOnInit() {
    //setting initial values
    this.emailRequest = new EmailRequest();
    this.emailRequest.to = "prashanth.ashokram@gmail.com";
    this.emailRequest.to_name = "Prashanth";
    this.emailRequest.from = "prashanth.ashokramkumar@gmail.com";
    this.emailRequest.from_name = "PARK";
    this.emailRequest.subject = "test email";
    this.emailRequest.body = "<h1>Your bill</h1><p>$10</p>";
  }

  onSubmit() {
    this.sendEmail();
  }
  sendEmail() {
    console.log(this.emailRequest);

    this.emailResponse$ = this.emailService.sendEmail(this.emailRequest);

    this.emailResponse$.subscribe(result => {
      console.log(result);
      this.emailResponse = result;
    });
  }

  reset() {
    this.emailResponse = null;
  }
}
