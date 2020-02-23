import { ViewEncapsulation, Component, OnInit, ViewChild } from "@angular/core";
import {
  EventSettingsModel,
  DayService,
  WeekService,
  WorkWeekService,
  ActionEventArgs,
  MonthService,
  AgendaService,
  GroupModel,
  ScheduleComponent
} from "@syncfusion/ej2-angular-schedule";
import {
  DataManager,
  Query,
  Predicate,
  ODataV4Adaptor
} from "@syncfusion/ej2-data";

@Component({
  selector: "app-root",
  templateUrl: "app.component.html",
  styleUrls: ["app.component.css"],
  encapsulation: ViewEncapsulation.None,
  providers: [MonthService, WorkWeekService]
})
export class AppComponent {
  public scheduleObj: ScheduleComponent;
  public start;
  public end;
  public selectedDate: Date = new Date(2018, 3, 1);
  private dataManger: DataManager = new DataManager({
    url: "http://localhost:25255/odata",
    crossDomain: true,
    adaptor: new ODataV4Adaptor()
  });
  public querySource: Query  = new Query().from("EventDatas");
  public eventSettings: EventSettingsModel = {
    dataSource: this.dataManger,
    query: this.querySource
  };

  ngOnInit(): void {}

  public onDataBound(args: any) {
    this.end = new Date();
    console.log(this.end - this.start);
  }
  public onActionBegin(args: ActionEventArgs) {
    this.start = new Date();
  }
}
