import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { PostDto } from './post-dto.type';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [CommonModule, RouterOutlet],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
    title = 'MediatorExampleClient';
    readonly baseUrl = 'http://localhost:5298/api/blogs';

    posts: Observable<PostDto[]> = this.http.get<PostDto[]>(`${this.baseUrl}`).pipe(
        map((posts: PostDto[]) => [...posts].sort((a, b) => a.title.localeCompare(b.title)))
    );

    constructor(private http: HttpClient) {

    }
}
