---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.IsCompatibleWith(Autodesk.Revit.DB.FabricationService)
source: html/e5a1a4bc-fcfb-9b02-c76c-98d42ed424a5.htm
---
# Autodesk.Revit.DB.FabricationService.IsCompatibleWith Method

Check whether the service is broadly interchangable with another one without affecting part geometry. The services must have the same fabrication system template and specification.

## Syntax (C#)
```csharp
public bool IsCompatibleWith(
	FabricationService otherService
)
```

## Parameters
- **otherService** (`Autodesk.Revit.DB.FabricationService`)

## Returns
Returns true if the services are compatible.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

