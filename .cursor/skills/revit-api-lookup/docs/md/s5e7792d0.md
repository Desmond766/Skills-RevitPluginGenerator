---
kind: method
id: M:Autodesk.Revit.DB.WorksetConfiguration.Close(System.Collections.Generic.IList{Autodesk.Revit.DB.WorksetId})
source: html/1e4d95c3-ced8-97a9-eff6-ee0752d87d37.htm
---
# Autodesk.Revit.DB.WorksetConfiguration.Close Method

Sets a group of user-created worksets to close.

## Syntax (C#)
```csharp
public void Close(
	IList<WorksetId> worksetsToClose
)
```

## Parameters
- **worksetsToClose** (`System.Collections.Generic.IList < WorksetId >`) - The group of user-created worksets to close. Non-user-created worksets and invalid workset ids will be ignored.

## Remarks
Calling this method on a configuration created with options other than WorksetConfigurationOption.CloseAllWorksets will set these
 worksets to be explicitly closed. If all worksets are set to close, the configuration will be unchanged. Worksets other than the inputs are unaffected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

