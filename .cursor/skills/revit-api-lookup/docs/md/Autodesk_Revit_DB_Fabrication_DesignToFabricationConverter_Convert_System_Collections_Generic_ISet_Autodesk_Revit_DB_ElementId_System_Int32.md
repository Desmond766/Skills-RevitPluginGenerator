---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.Convert(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},System.Int32)
source: html/46847fac-35ed-6f3a-d255-e5b0463f5e65.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.Convert Method

Converts the set of MEP design elements into fabrication parts.

## Syntax (C#)
```csharp
public DesignToFabricationConverterResult Convert(
	ISet<ElementId> selection,
	int serviceId
)
```

## Parameters
- **selection** (`System.Collections.Generic.ISet < ElementId >`) - The set of element identifiers to convert from MEP design elements to fabrication parts.
- **serviceId** (`System.Int32`) - The identifier of the fabrication service.

## Remarks
After this method has been invoked, call:
 GetConvertedFabricationParts () () () to get a set of element identifiers for the newly created fabrication parts. GetElementsWithOpenConnector () () () to get a set of fabrication part or MEP design element identifiers with open connectors, caused by fittings failing to convert.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the selection contains invalid elements to convert.
 -or-
 the specified fabrication service is not valid for all domains in the selection.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - no fabrication configuration is loaded.

