---
kind: method
id: M:Autodesk.Revit.DB.WorksetConfiguration.Open(System.Collections.Generic.IList{Autodesk.Revit.DB.WorksetId})
source: html/6fd8d399-0b42-784d-5863-cc6618499ad8.htm
---
# Autodesk.Revit.DB.WorksetConfiguration.Open Method

Sets a group of user-created worksets to open.

## Syntax (C#)
```csharp
public void Open(
	IList<WorksetId> worksetsToOpen
)
```

## Parameters
- **worksetsToOpen** (`System.Collections.Generic.IList < WorksetId >`) - The group of user-created worksets to open. Non-user-created worksets and invalid workset ids will be ignored.

## Remarks
Calling this method on a configuration created with options other than WorksetConfigurationOption.OpenAllWorksets will set these
 worksets to be explicitly opened. If all worksets are set to open, the configuration will be unchanged. Worksets other than the inputs are unaffected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

