import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-health-check",
  templateUrl: "./health-check.component.html",
  styleUrls: ["./health-check.component.css"]
})
export class HealthCheckComponent implements OnInit {
  apiHealth: string;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    // http.get(baseUrl + "api/email").subscribe(
    //   result => {
    //     console.log(result);
    //     // this.apiHealth = result;
    //   },
    //   error => console.error(error)
    // );

    http.get(baseUrl + "api/default/5").subscribe(
      result => {
        console.log(result);
        // this.apiHealth = result;
      },
      error => console.error(error)
    );
  }

  ngOnInit() {
    console.log("inside ngOnInit");
  }
}
