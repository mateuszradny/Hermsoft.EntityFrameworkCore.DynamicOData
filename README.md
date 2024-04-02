 <!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Hermsoft.EntityFrameworkCore.DynamicOData</h3>
  <p align="center">
    This is a library that makes it easy to expose OData APIs based on DbContext definitions. By using this library you can save time on required controller code, model edm, etc.
    <br />
    <a href="https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData"><strong>Explore the docs »</strong></a>
    <br />
    ·
    <a href="https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/issues">Report Bug</a>
    ·
    <a href="https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData)

Library created as part of the (https://100commitow.com) competition

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

- [.NET Core](https://dotnet.microsoft.com/)
- [EF Core](https://learn.microsoft.com/en-us/ef/core/)
- [OData](https://www.odata.org/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* .NET Core 9.0

### Installation

In preparation...

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage 
The only thing you need to do to use this library is to call the function `AddDynamicOData()`:

```csharp
// Add services to the container.
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesConnectionString"))
);

builder.Services.AddDbContext<HRDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRConnectionString"))
);

builder.Services.AddControllers()
    .AddDynamicOData<SalesDbContext>(options =>
    {
        options.RoutePrefix = "sales";
        options.IsEntityTypeAutorized = type => false;
    })
    .AddDynamicOData<HRDbContext>(options =>
    {
        options.RoutePrefix = "hr";
        options.IsEntityTypeAutorized = type => true;
    });

// ...

app.MapControllers();
```
After that you can navigate to `/sales/entity_name` or `/hr/entity_name`

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Dynamic OData Controllers and EDM Model
- [x] Ability to inject custom code to handle OData requests

See the [open issues](https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Mateusz Radny - mateuszradnywrz@gmail.com

Project Link: [https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData](https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [100commitow.pl](100commitow.pl)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[100commitow.pl]: https://100commitow.pl/
[contributors-shield]: https://img.shields.io/github/contributors/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData.svg?style=for-the-badge
[contributors-url]: https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData.svg?style=for-the-badge
[forks-url]: https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/network/members
[stars-shield]: https://img.shields.io/github/stars/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData.svg?style=for-the-badge
[stars-url]: https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/stargazers
[issues-shield]: https://img.shields.io/github/issues/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData.svg?style=for-the-badge
[issues-url]: https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/issues
[license-shield]: https://img.shields.io/github/license/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData.svg?style=for-the-badge
[license-url]: https://github.com/mateuszradny/Hermsoft.EntityFrameworkCore.DynamicOData/blob/main/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/mateusz-radny-71379ab5/
[product-screenshot]: images/logo.png
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
