<a name="readme-top"></a>

<!-- LINK AUF TRELLO -->

<div align="center">

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Last Commit][last-commit-shield]][last-commit-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

</div>


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">AR Cooking Recipe</h3>

  <p align="center">
    Student project using mixed reality for the State Cooperative University Heidenheim.<br />
    This project is optimized for the use of a <a href="https://www.microsoft.com/en-us/hololens/hardware">Microsoft HoloLens 2</a> and is made in <a href="https://unity.com/">Unity</a>.
    <br />
    <!-- <a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a> -->
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
  </p>
</div>
<div align="center">

[![Trello][trello-shield]][trello-url]

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

<!-- [![Product Name Screen Shot][product-screenshot]](https://example.com) -->

To introduce students to the concepts of AR and XR development, during the final semester of the General Computer Science course at the State Cooperative University Heidenheim a project is conducted to develop an application based on pre-selected ideas. In this case the focal point of the project is the interactivity with the AR environment.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With


* ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
* ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
* ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
* MRTK2

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built For


* ![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

For use of this application either of two options is possible:
1. Use of a <a href="https://www.microsoft.com/en-us/hololens/hardware">Microsoft HoloLens 2</a> for display and interaction.
2. Use of the <a href="https://docs.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/using-the-hololens-emulator">HoloLens 2 Emulator</a>. This solution additionally requires <a href="https://visualstudio.microsoft.com/downloads/">Visual Studio</a> to launch the application with the emulator as target.

### Installation

If you wish to build the application yourself, follow the steps below:

1. Clone the repo
   ```sh
   git clone https://github.com/ilinga/Cooking_Recipe.git
   ```

2. Install Unity Editor version <a href="https://unity3d.com/unity/whats-new/2020.3.38">2020.3.38f1</a> with additional modules:
    * Universal Windows Platform Build Support
    * Windows Build Support IL2PCC

3. Open the project in this Unity installation and let it build all assemblies (might take multiple minutes).
4. Build your app with the Windows platform as target. (Picture?)

Either follow the above steps <b>OR</b> download the <a href="https://github.com/ilinga/Cooking_Recipe/releases">latest release</a> from the repository to have the deployable solution.
Afterwards follow the steps described under "Deploying Apps to the HoloLens Emulator" in <a href="https://docs.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/using-the-hololens-emulator#deploying-apps-to-the-hololens-emulator">the HoloLens documentation</a>.
1. Open the solution in <a href="https://visualstudio.microsoft.com/downloads/">Visual Studio</a>.
2. Ensure build target is <b>x64</b> or <b>x86</b>.
3. Select <b>HoloLens Emulator</b> as target device.
4. Go to <b>Debug</b> -> <b>Start Debugging</b>

Alternatively, if a hardware <a href="https://www.microsoft.com/en-us/hololens/hardware">HoloLens 2</a> is used, directly deploy to it in Visual Studio.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Choose a recipe
- [x] Define interaction concept
- [x] Define individual cooking steps
- [x] Model 3D objects
- [x] Create Unity project
- [x] Coding object interaction
    - [x] Collision
    - [x] "Grabbability"
- [ ] Desgin menu and UI
    - [ ] Recipe selection
    - [ ] Recipe details
    - [ ] Participant adjustment
- [ ] Coding step-by-step recipe progress
    - [ ] Framework for stepping through recipe
    - [ ] Data models
    - [ ] Populating for Carbonara recipe
- [ ] Analyze usability


See the [open issues](https://github.com/ilinga/Cooking_Recipe/issues) list of known issues.

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

Distributed under the [MIT](https://en.wikipedia.org/wiki/MIT_License) License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Project Link: [https://github.com/ilinga/Cooking_Recipe/](https://github.com/ilinga/Cooking_Recipe/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* The [AuReLiA](https://www.heidenheim.dhbw.de/forschung-transfer/labore/aurelia) lab at DHBW Heidenheim for making this project possible and supplying us with tools and materials.
* [Choose an Open Source License](https://choosealicense.com)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/ilinga/Cooking_Recipe?style=for-the-badge
[contributors-url]: https://github.com/ilinga/Cooking_Recipe/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/ilinga/Cooking_Recipe?style=for-the-badge
[forks-url]: https://github.com/ilinga/Cooking_Recipe/network/members
[last-commit-shield]: https://img.shields.io/github/last-commit/ilinga/Cooking_Recipe?style=for-the-badge
[last-commit-url]: https://github.com/ilinga/Cooking_Recipe/graphs/commit-activity
[issues-shield]: https://img.shields.io/github/issues/ilinga/Cooking_Recipe/issues?style=for-the-badge
[issues-url]: https://github.com/ilinga/Cooking_Recipe/issues
[license-shield]: https://img.shields.io/github/license/ilinga/Cooking_Recipe?style=for-the-badge
[license-url]: https://github.com/ilinga/Cooking_Recipe/blob/main/LICENSE
[product-screenshot]: images/screenshot.png


[trello-shield]: https://img.shields.io/badge/Trello-%23026AA7.svg?style=for-the-badge&logo=Trello&logoColor=white
[trello-url]: https://trello.com/b/yeJ4cP26/aufgaben


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
