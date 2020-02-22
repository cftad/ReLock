<div align="center">
  <img width="30%" src="logo.png">
</div>

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Roadmap](#roadmap)
- [Build Process](#build-process)
- [Feedback](#feedback)
- [Acknowledgments](#acknowledgements)

## Introduction

[![Build Status](https://img.shields.io/travis/cftad/ReLock.svg?style=flat-square)](https://travis-ci.org/gitpoint/git-point)
[![Contributors](https://img.shields.io/github/contributors/cftad/ReLock?style=flat-square)](./CONTRIBUTORS.md)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](https://opensource.org/licenses/MIT)

ReLock helps get current user credentials by popping a fake Windows lock screen.

![Working ReLock](screenshot.png)

## Features

- Obtains the user's profile image. (Anti-aliased)
- Obtains the user's current lockscreen (Including Spotlight Images)
- Displays the current date and time.
- Uses Segoe MDL2 Assets for icons.

## Roadmap

To see the future features, see [Projects](https://github.com/cftad/ReLock/projects).

## Current State

At the moment there are two separate applications, the legacy winforms app, and the rebuild WPF. [Fody](https://github.com/Fody/Fody) and [Costura](https://github.com/Fody/Costura) are used to embed `ReLock.Core` as part of the main executables.

- **ReLock (WIP)** - The new WPF app, created to enable more control over the styling to better emulate the lockscreen.

- **ReLock.Core** - Used for shared logic which can be used by both the WPF and Winforms apps.

### Deprecated

- **SharpLocker-Winforms** - The previous application by [@Pickfordmatt](https://github.com/Pickfordmatt/SharpLocker), *intended only to be used in Cobalt Strike.*

## Build Process

Some of the methods used to obtain information from the local machine require accessing the registry, this is done to avoid lengthy calls to system APIs. As a result it is important that care is taken to ensure the application is built for its target platform (x86 for 32 bit and x64 for 64 bit systems) else *silent registry redirection will occur and the application will fail to launch*


## How To Use

[Download](/releases) the latest version.

[![forthebadge](https://forthebadge.com/images/badges/powered-by-responsibility.svg)](https://forthebadge.com)

## Feedback

Feel free to file an issue. Feature requests are always welcome. If you wish to contribute, please take a quick look at the guidelines!

## Acknowledgements

This application is based on the original winforms app by [@Pickfordmatt](https://github.com/Pickfordmatt/SharpLocker)
