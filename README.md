sqlcmd -S locaalhost.database.windows.net -d appdb -U CloudSAcbd8209c -P Ashu@123 -C



<!-- Auth Guard -->


import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
      return false;
    }

    // Role-based guard
    const expectedRole = route.data?.['role'];
    if (expectedRole && this.authService.getUserRole() !== expectedRole) {
      // Redirect based on actual role
      const role = this.authService.getUserRole();
      if (role === 'Admin') {
        this.router.navigate(['/admin-dashboard']);
      } else {
        this.router.navigate(['/customer-dashboard']);
      }
      return false;
    }

    return true;
  }
}

<!-- ============================================================= -->

<!-- Auth Service -->


import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { User } from '../models/user.model';
import { environment } from 'src/environments/nvironment';


@Injectable({ providedIn: 'root' })
export class AuthService {
  public apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

 
  register(user: User, adminKey?: string): Observable<any> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (adminKey) {
      headers = headers.set('X-Admin-Key', adminKey);
    }
    return this.http.post(`${this.apiUrl}/api/register`, user, { headers }).pipe(
      tap((res: any) => {
        if (res) {
          localStorage.setItem('userId', res.userId?.toString() || '');
          localStorage.setItem('userRole', res.userRole || '');
          localStorage.setItem('username', res.username || '');
          
        }
      }),
      catchError(err => throwError(() => err))
    );
  }

  /**
   * Login and store JWT token data in localStorage
   */
  login(email: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/login`, { email, password }).pipe(
      tap((res: any) => {
        if (res && res.token) {
          localStorage.setItem('token', res.token);
          localStorage.setItem('userId', res.userId?.toString() || '');
          localStorage.setItem('userRole', res.userRole || '');
          localStorage.setItem('username', res.username || '');
        }
      }),
      catchError(err => throwError(() => err))
    );
  }

  /** Logout and clear localStorage */
  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('userRole');
    localStorage.removeItem('username');
    localStorage.removeItem('user');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getUserRole(): string {
    return localStorage.getItem('userRole') || '';
  }

  getUserId(): number {
    return parseInt(localStorage.getItem('userId') || '0', 10);
  }

  getUsername(): string {
    const user =  localStorage.getItem('username');
    return user? user : '';
   }

  getToken(): string {
    return localStorage.getItem('token') || '';
  }
}



<!-- ============================================================== -->

<!-- Login component -->

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ThemeService } from '../../services/theme.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email = '';
  password = '';
  errorMsg = '';
  isLoading = false;
  showPassword = false;

  constructor(private authService: AuthService, private router: Router, public theme: ThemeService) {}

  onLogin(): void {
    if (!this.email || !this.password) {
      this.errorMsg = 'Please enter email and password.';
      setTimeout(()=>{
        this.errorMsg = '';
      },3000);
      return;
    }

    this.isLoading = true;
    this.errorMsg = '';

    this.authService.login(this.email, this.password).subscribe({
      next: (res) => {
        
        localStorage.setItem('username',this.email.split('@')[0]);
        localStorage.setItem('role', res.userRole);
        localStorage.setItem('token', res.token);
        localStorage.setItem('userId', res.userId);

        if(res.userRole === 'Admin'){
          this.router.navigate(['/admin-dashboard']);
        }else{
          
          this.router.navigate(['/customer-dashboard']);
        }
      },
        error: ()=>{
          this.isLoading=false;
          this.errorMsg = 'Invalid email or password';
          setTimeout(()=>{
            this.errorMsg = '';
          },3000);

        
      }
     });
  }
}




<!-- login - HTML -->


<form (ngSubmit)="onLogin()">
<div class="login-page">
  <!-- Theme toggle -->
  <button class="page-theme-toggle" (click)="theme.toggle()" [title]="theme.isDark ? 'Switch to Light Mode' : 'Switch to Dark Mode'">
    <i class="fas" [class.fa-sun]="theme.isDark" [class.fa-moon]="!theme.isDark"></i>
  </button>

  <!-- Animated background particles -->
  <div class="particles">
    <div class="particle" *ngFor="let p of [1,2,3,4,5,6,7,8,9,10,11,12]" [style.animation-delay]="(p * 0.3) + 's'"></div>
  </div>

  <!-- Balloons animation on load -->
  <div class="balloons">
    <div class="balloon" *ngFor="let b of [1,2,3,4,5]" [style.animation-delay]="(b * 0.5) + 's'" [style.left]="(b * 18) + '%'">🎈</div>
  </div>

  <div class="login-container">
    <!-- Left panel -->
    <div class="login-left">
      <div class="left-content">
        <div class="logo-area">
          <div class="logo-icon">🎉</div>
          <h1>CelebrateSpot</h1>
          <p>Your Perfect Party Hall Awaits</p>
        </div>
        <div class="feature-list">
          <div class="feature-item">
            <div class="feature-icon">🏛️</div>
            <div>
              <h4>Premium Venues</h4>
              <p>Handpicked luxury party halls</p>
            </div>
          </div>
          <div class="feature-item">
            <div class="feature-icon">✨</div>
            <div>
              <h4>Easy Booking</h4>
              <p>Book your perfect event space instantly</p>
            </div>
          </div>
          <div class="feature-item">
            <div class="feature-icon">⭐</div>
            <div>
              <h4>Verified Reviews</h4>
              <p>Trusted by thousands of customers</p>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Right panel - Login form -->
    <div class="login-right">
      <div class="login-card animate-fadeInUp">
        <div class="card-header">
          <h2>Welcome Back</h2>
          <p>Sign in to your account</p>
        </div>

        <div class="alert alert-error" *ngIf="errorMsg">
          <i class="fas fa-exclamation-circle"></i> {{ errorMsg }}
        </div>

        <div class="form-group">
          <label class="form-label">Email Address *</label>
          <div class="input-wrapper">
            <i class="fas fa-envelope input-icon"></i>
            <input
              type="email"
              class="form-control"
              name="email"
              [(ngModel)]="email"
              placeholder="your@email.com"
              required
            >
          </div>
        </div>

        <div class="form-group">
          <label class="form-label">Password *</label>
          <div class="input-wrapper">
            <i class="fas fa-lock input-icon"></i>
            <input
              [type]="showPassword ? 'text' : 'password'"
              class="form-control"
              name="password"
              [(ngModel)]="password"
              placeholder="Enter your password"
              required
            >
            <button class="toggle-password" (click)="showPassword = !showPassword" type="button">
              <i [class]="showPassword ? 'fas fa-eye-slash' : 'fas fa-eye'"></i>
            </button>
          </div>
        </div>

        <button class="btn-gold login-btn" type="submit" [disabled]="isLoading">
          <span *ngIf="!isLoading">Sign In <i class="fas fa-arrow-right"></i></span>
          <span *ngIf="isLoading"><span class="spinner-sm"></span> Signing in...</span>
        </button>

        <div class="register-link">
          Don't have an account?
          <a routerLink="/register">Create Account</a>
        </div>
      </div>
    </div>
  </div>
</div>
</form>



<!-- ================================================================ -->


<!-- registration component -->


import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/user.model';
import { ThemeService } from '../../services/theme.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  standalone: true,
  imports:[CommonModule, FormsModule,RouterModule], 
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  user: User = {
    email: '',
    password: '',
    username: '',
    mobileNumber: '',
    userRole: 'Customer'
  };
  confirmPassword = '';
  adminKey = '';
  errorMsg = '';
  successMsg = '';
  isLoading = false;
  showPassword = false;

  get passwordStrength(): 'weak' | 'strong' | 'very-strong' {
    const p = this.user.password;
    if (!p || p.trim().length < 6 || /\s/.test(p)) return 'weak';
    const hasUpper = /[A-Z]/.test(p);
    const hasLower = /[a-z]/.test(p);
    const hasNumber = /[0-9]/.test(p);
    const hasSpecial = /[^A-Za-z0-9]/.test(p);
    if (p.length >= 8 && hasUpper && hasLower && hasNumber && hasSpecial) return 'very-strong';
    if (p.length >= 6 && ((hasUpper || hasLower) && hasNumber)) return 'strong';
    return 'weak';
  }

  constructor(private authService: AuthService, private router: Router, public theme: ThemeService) {}

  onRegister(): void {
    // Trim all fields before validation
    this.user.username = this.user.username.trim();
    this.user.email = this.user.email.trim();
    this.user.mobileNumber = this.user.mobileNumber.trim();

    if (!this.user.email || !this.user.password || !this.user.username || !this.user.mobileNumber) {
      this.errorMsg = 'All fields are required.';
      return;
    }
    if (/\s/.test(this.user.password)) {
      this.errorMsg = 'Password must not contain spaces.';
      return;
    }
    if (this.user.password !== this.confirmPassword) {
      this.errorMsg = 'Passwords do not match.';
      return;
    }
    if (this.user.password.length < 6) {
      this.errorMsg = 'Password must be at least 6 characters.';
      return;
    }
    if (!/^\d{10}$/.test(this.user.mobileNumber)) {
      this.errorMsg = 'Mobile number must be 10 digits.';
      return;
    }
    if (this.user.userRole === 'Admin' && !this.adminKey.trim()) {
      this.errorMsg = 'Admin secret key is required.';
      return;
    }
    this.adminKey = this.adminKey.trim();

    this.isLoading = true;
    this.errorMsg = '';

    const keyToUse = this.user.userRole === 'Admin' ? this.adminKey : undefined;

    this.authService.register(this.user, keyToUse).subscribe({
      next: () => {
        this.isLoading = false;
        this.successMsg = 'Registration successful! Redirecting to login...';
        setTimeout(() => this.router.navigate(['/login']), 1500);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMsg = err.error?.message || 'Registration failed. Please try again.';
      }
    });
  }
}



<!-- registration.html -->


<div class="register-page">
  <!-- Theme toggle -->
  <button class="page-theme-toggle" (click)="theme.toggle()" [title]="theme.isDark ? 'Switch to Light Mode' : 'Switch to Dark Mode'">
    <i class="fas" [class.fa-sun]="theme.isDark" [class.fa-moon]="!theme.isDark"></i>
  </button>

  <div class="particles">
    <div class="particle" *ngFor="let p of [1,2,3,4,5,6,7,8]" [style.animation-delay]="(p * 0.4) + 's'"></div>
  </div>

  <div class="register-container animate-fadeInUp">
    <div class="register-header">
      <a routerLink="/login" class="back-btn"><i class="fas fa-arrow-left"></i></a>
      <div class="logo">
        <span class="logo-emoji">🎉</span>
        <h1>CelebrateSpot</h1>
      </div>
      <h2>Create Account</h2>
      <p>Join thousands of happy customers</p>
    </div>

    <div class="alert alert-error" *ngIf="errorMsg">
      <i class="fas fa-exclamation-circle"></i> {{ errorMsg }}
    </div>
    <div class="alert alert-success" *ngIf="successMsg">
      <i class="fas fa-check-circle"></i> {{ successMsg }}
    </div>

    <div class="form-grid">
      <div class="form-group">
        <label class="form-label">Username *</label>
        <div class="input-wrapper">
          <i class="fas fa-user input-icon"></i>
          <input type="text" class="form-control" name="username" [(ngModel)]="user.username" placeholder="John Doe" required>
        </div>
      </div>

      <div class="form-group">
        <label class="form-label">Email Address *</label>
        <div class="input-wrapper">
          <i class="fas fa-envelope input-icon"></i>
          <input type="email" class="form-control" name="email" [(ngModel)]="user.email" placeholder="your@email.com" required>
        </div>
      </div>

      <div class="form-group">
        <label class="form-label">Password *</label>
        <div class="input-wrapper">
          <i class="fas fa-lock input-icon"></i>
          <input [type]="showPassword ? 'text' : 'password'" class="form-control" name="password" [(ngModel)]="user.password"
                 placeholder="Min. 6 characters" required
                 (keydown.space)="$event.preventDefault()">
          <button class="toggle-password" (click)="showPassword = !showPassword" type="button">
            <i [class]="showPassword ? 'fas fa-eye-slash' : 'fas fa-eye'"></i>
          </button>
        </div>
        <div class="password-strength" *ngIf="user.password">
          <div class="strength-bar">
            <div class="strength-fill" [class]="passwordStrength"></div>
          </div>
          <span class="strength-label" [class]="passwordStrength">
            <ng-container *ngIf="passwordStrength === 'weak'">Weak</ng-container>
            <ng-container *ngIf="passwordStrength === 'strong'">Strong</ng-container>
            <ng-container *ngIf="passwordStrength === 'very-strong'">Very Strong</ng-container>
          </span>
        </div>
      </div>

      <div class="form-group">
        <label class="form-label">Confirm Password *</label>
        <div class="input-wrapper">
          <i class="fas fa-lock input-icon"></i>
          <input [type]="showPassword ? 'text' : 'password'" class="form-control"
                 [class.input-match]="confirmPassword && user.password === confirmPassword"
                 [class.input-mismatch]="confirmPassword && user.password !== confirmPassword" name="confirmPassword" 
                 [(ngModel)]="confirmPassword"
                 placeholder="Re-enter password" required
                 (keydown.space)="$event.preventDefault()">
          <i class="fas fa-check-circle confirm-icon match" *ngIf="confirmPassword && user.password === confirmPassword"></i>
          <i class="fas fa-times-circle confirm-icon mismatch" *ngIf="confirmPassword && user.password !== confirmPassword"></i>
        </div>
        <p class="confirm-msg match" *ngIf="confirmPassword && user.password === confirmPassword">
          <i class="fas fa-check"></i> Passwords match
        </p>
        <p class="confirm-msg mismatch" *ngIf="confirmPassword && user.password !== confirmPassword">
          <i class="fas fa-times"></i> Passwords do not match
        </p>
      </div>

      <div class="form-group">
        <label class="form-label">Mobile Number *</label>
        <div class="input-wrapper">
          <i class="fas fa-phone input-icon"></i>
          <input type="tel" class="form-control" name="mobileNumber" [(ngModel)]="user.mobileNumber" placeholder="10-digit number" maxlength="10" required>
        </div>
      </div>

      <div class="form-group">
        <label class="form-label">Account Type *</label>
        <div class="input-wrapper">
          <i class="fas fa-user-tag input-icon"></i>
          <select class="form-control" name="userRole" [(ngModel)]="user.userRole">
            <option value="Customer">Customer</option>
            <option value="Admin">Admin</option>
          </select>
        </div>
      </div>
    </div>

    <!-- Admin key field -->
    <div class="form-group admin-key-field" *ngIf="user.userRole === 'Admin'">
      <label class="form-label">
        <i class="fas fa-key"></i> Admin Secret Key *
        <span class="hint-badge">Required for Admin registration</span>
      </label>
      <div class="input-wrapper">
        <i class="fas fa-shield-alt input-icon"></i>
        <input type="password" class="form-control"  name="adminKey" [(ngModel)]="adminKey" placeholder="Enter admin secret key" required>
      </div>
      <p class="admin-hint">
        <i class="fas fa-info-circle"></i>
        Contact your administrator for the secret key.
      </p>
    </div>

    <button class="btn-gold register-btn" (click)="onRegister()" [disabled]="isLoading">
      <span *ngIf="!isLoading">Create Account <i class="fas fa-arrow-right"></i></span>
      <span *ngIf="isLoading"><span class="spinner-sm"></span> Creating account...</span>
    </button>

    <div class="login-link">
      Already have an account? <a routerLink="/login">Sign In</a>
    </div>
  </div>
</div>




<!-- ============================================================= -->


📦dotnetapp
 ┣ 📂Controllers
 ┃ ┣ 📜BookingController.cs
 ┃ ┣ 📜PartyHallController.cs
 ┃ ┣ 📜ReviewController.cs
 ┃ ┗ 📜UserController.cs
 ┣ 📂Data
 ┃ ┗ 📜ApplicationDbContext.cs
 ┣ 📂Exceptions
 ┃ ┗ 📜PartyHallException.cs
 ┣ 📂Migrations
 ┃ ┣ 📜20260304180933_in.Designer.cs
 ┃ ┣ 📜20260304180933_in.cs
 ┃ ┗ 📜ApplicationDbContextModelSnapshot.cs
 ┣ 📂Models
 ┃ ┣ 📜Booking.cs
 ┃ ┣ 📜LoginModel.cs
 ┃ ┣ 📜PartyHall.cs
 ┃ ┣ 📜Review.cs
 ┃ ┣ 📜User.cs
 ┃ ┗ 📜UserRoles.cs
 ┣ 📂Properties
 ┃ ┗ 📜launchSettings.json
 ┣ 📂Services
 ┃ ┣ 📜BookingService.cs
 ┃ ┣ 📜PartyHallService.cs
 ┃ ┣ 📜ReviewService.cs
 ┃ ┗ 📜UserService.cs
 ┣ 📜.env.example
 ┣ 📜Program.cs
 ┣ 📜appsettings.Development.json
 ┣ 📜appsettings.json
 ┣ 📜dotnet-tools.json
 ┣ 📜dotnetapp.csproj
 ┗ 📜dotnetapp.sln

