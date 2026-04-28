---
kind: method
id: M:Autodesk.Revit.DB.LinkOperations.SetOnLocalLinkSharedCoordinatesSavedCallback(Autodesk.Revit.DB.IOnLocalLinkSharedCoordinatesSavedCallback)
source: html/90328006-39f7-cce7-9011-df0883439cde.htm
---
# Autodesk.Revit.DB.LinkOperations.SetOnLocalLinkSharedCoordinatesSavedCallback Method

Sets the callback that will be called when the Revit user saves new shared coordinate
 settings to a linked document obtained from an IExternalResourceServer.

## Syntax (C#)
```csharp
public void SetOnLocalLinkSharedCoordinatesSavedCallback(
	IOnLocalLinkSharedCoordinatesSavedCallback onLocalLinkSharedCoordinatesSaved
)
```

## Parameters
- **onLocalLinkSharedCoordinatesSaved** (`Autodesk.Revit.DB.IOnLocalLinkSharedCoordinatesSavedCallback`) - An IOnLocalLinkSharedCoordinatesSavedCallback object that can respond when the user
 saves new shared coordinates to a Revit link document obtained from IExternalResourceServer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

