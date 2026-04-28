---
kind: method
id: M:Autodesk.Revit.DB.SiteLocation.IsCompatibleWith(Autodesk.Revit.DB.SiteLocation)
source: html/44ee825f-75c2-ebe3-f3cd-ca3b494e92e2.htm
---
# Autodesk.Revit.DB.SiteLocation.IsCompatibleWith Method

Checks whether the geographic coordinate system of this site is compatible with the given site .
 True if he geographic coordinate system of this site is compatible with the given site, false otherwise.

## Syntax (C#)
```csharp
public bool IsCompatibleWith(
	SiteLocation otherSiteLocation
)
```

## Parameters
- **otherSiteLocation** (`Autodesk.Revit.DB.SiteLocation`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

