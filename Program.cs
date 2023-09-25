namespace SimpleObjCInterop;

class Program 
{
	public static int Main(string[] args)
	{
		const string unresolvedPathCS = "~/Downloads";
		string resolvedPathCs = string.Empty;
		
		using (NSString unresolvedPathNS = new(unresolvedPathCS)) {
			using (NSString? resolvedPathNS = unresolvedPathNS.StringByResolvingSymlinksInPath) {
				if (resolvedPathNS is null) {
					throw new Exception("Failed to resolve path");
				}

				resolvedPathCs = resolvedPathNS.UTF8String ?? string.Empty;
			}
		}
		
		Console.WriteLine($"Unresolved Path: {unresolvedPathCS}");
		Console.WriteLine($"Resolved Path: {resolvedPathCs}");

		return 0;
	}
}