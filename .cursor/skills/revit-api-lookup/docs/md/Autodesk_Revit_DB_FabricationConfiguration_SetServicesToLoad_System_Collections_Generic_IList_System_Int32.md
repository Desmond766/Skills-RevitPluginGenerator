---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.SetServicesToLoad(System.Collections.Generic.IList{System.Int32})
source: html/bafcf7a1-c1c1-e908-9d80-31f71a7b6c86.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.SetServicesToLoad Method

Sets the services which are to be loaded or not next time reloadConfiguration is called. If a service is not included but is currently loaded then it will be unloaded then.

## Syntax (C#)
```csharp
public bool SetServicesToLoad(
	IList<int> serviceIds
)
```

## Parameters
- **serviceIds** (`System.Collections.Generic.IList < Int32 >`)

## Returns
Returns true if successful. May fail if any service currently loaded is not included and is in use so cannot be unloaded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

