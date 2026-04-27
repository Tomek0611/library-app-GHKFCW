import { Routes } from '@angular/router';
import { BookListComponent } from './components/books/book-list/book-list.component';
import { BookDetailComponent } from './components/books/book-detail/book-detail.component';
import { AuthorListComponent } from './components/authors/author-list/author-list.component';
import { AboutComponent } from './components/shared/about/about.component';

export const routes: Routes = [
  { path: '', redirectTo: 'books', pathMatch: 'full' },
  { path: 'books', component: BookListComponent },
  { path: 'books/:id', component: BookDetailComponent },
  { path: 'authors', component: AuthorListComponent },
  { path: 'about', component: AboutComponent },
];
