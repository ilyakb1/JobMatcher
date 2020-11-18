import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html'
})
export class JobsComponent {
  public JobWithCandidates: JobWithCandidate[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<JobWithCandidate[]>(baseUrl + 'jobs').subscribe(result => {
      this.JobWithCandidates = result;
    }, error => console.error(error));
  }
}

interface JobWithCandidate {
  job: Job;
  candidate: Candidate;
}

interface Job {
  jobId: number;
  name: string;
  company: string;
  skills: string;
}

interface Candidate {
  candidateId: number;
  name: string;
  skillTags: string;
}
