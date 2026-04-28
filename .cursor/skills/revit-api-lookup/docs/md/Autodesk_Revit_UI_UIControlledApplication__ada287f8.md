---
kind: type
id: T:Autodesk.Revit.UI.UIControlledApplication
source: html/4638c568-a118-1d57-ceed-a57595202644.htm
---
# Autodesk.Revit.UI.UIControlledApplication

Represents the Autodesk Revit user interface, providing access to
UI customization methods and events.

## Syntax (C#)
```csharp
public class UIControlledApplication
```

## Remarks
This class does not provide access to documents because it is provided to you through the ExternalApplication
OnStartup()/OnShutdown() methods, and those methods are when it is not possible to work with Revit documents. 
You can work with documents by getting them from the UIApplication class; that class is obtained from events and 
ExternalCommand callbacks.

