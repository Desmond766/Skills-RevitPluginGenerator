---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.LoadAddIn(System.String)
source: html/b83c88f3-8861-d89c-fc36-b98b88673782.htm
---
# Autodesk.Revit.UI.UIControlledApplication.LoadAddIn Method

Loads add-ins from the given manifest file.

## Syntax (C#)
```csharp
public void LoadAddIn(
	string fileName
)
```

## Parameters
- **fileName** (`System.String`) - The name of the add-in manifest file including the extension is to identify the 
manifest file which contains Revit add-ins.

## Remarks
This method loads the add-ins listed in the provided add-in manifest file. 
The API will look for the file in the dedicated folders supported by Revit for loading add-in manifest files. Some add-ins may have settings in which they decline the ability for Revit to load the external application declared 
in the .addin in mid-session. 
This happens when the AllowLoadingIntoExistingSession tag is set to "No" in the add-in manifest file, and if the tag
isn't present, the default is set to "Yes". Note that when Revit starts an add-in in the middle of the session, some add-in logic may not function as expected 
because of the different interactions with the session. Specifically:
 If the application's goal is to prevent something from happening, the application may not be able to handle
the fact that this activity has already happened in the existing session. If the application's goal is to manage external information in synch with documents loaded in the session, 
the application may not be able to handle documents that were loaded before the application started. If the application's logic depends on the ApplicationInitialized event, this event has already been called 
before the add-in was loaded. Also, some add-ins may not be able to fully initialize when loading in the middle of the session. This is because some
activities must take place at the start of the Revit session:
 Creation of custom failure definitions Establishment of a system-wide IFailureProcessor to handle all failures. Registering ExternalServices.

## Exceptions
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - Thrown when manifest file which is specified by 
fileName doesn't exist.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the fileName is null or empty.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the fileName doesn't end with 'addin'.
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown if the manifest file can't be parsed successfully.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when any of the newly added external 
applications fails to load and/or initialize properly, possibly because of one of the following reasons:
AllowLoadingIntoExistingSession property is 'No'.Client id is duplicated.External application start up failed.

