# TWAIN scanner
Software that scans documents using TWAIN protocol. This software use NTwain library to scan images from selected device, form PDF with PDFSharp and return it as a PDF file.

## Installation
* Install your scanner driver.
* Open TWAIN-scanner.sln as Administrator.
* Make sure you do not have this software installed. If you have it installed — uninstall it from Control Panel.
* Build Setup project.
* Right-click on Setup project -> Install.
* Click "YES" to add firewall exception for non-administrative users.

## Available API
API's structure is as follows: `{controller}/{action}`. There are two controllers:
* ScansController
    * Get (GET). Returns "application/pdf" content type data or 400 status code with error message.

## Uninstallation via Visual Studio
Use this method if installation was also performed via Visual Studio.
* Right-click on Setup project -> Uninstall.
* Go trough all dialogs and service should be now uninstalled.

## Uninstallation via Control Panel
* Open Control Panel -> Programs -> Uninstall a program
* Find "TWAIN", from "Varutis" publisher -> Uninstall
* Go trough all dialogs and service should be now uninstalled.

# FAQ
1. Can't unisnatll Service.
    * Service Setup.msi was overriden by new version and so it might be unable to uninstall. In this case use [Uninstallation tool](https://support.microsoft.com/en-us/help/17588/windows-fix-problems-that-block-programs-being-installed-or-removed "Unisntall fix tool."). Remove service manually mentioned in Uninstallation step.
