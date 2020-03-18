import yaml

def main():
	yml = yaml.load(file('scir.yml'), Loader=yaml.Loader)
	types = sorted(yml.items(), key=lambda x: x[0])
	with file('Scir.cs', 'w') as fp:
		print >>fp, 'using System;'
		print >>fp, 'using PrettyPrinter;'
		print >>fp
		print >>fp, 'namespace CorePrecompiler {'
		print >>fp, '\tpublic abstract class Scir {'
		print >>fp, '\t\tpublic readonly Type Type;'
		print >>fp, '\t\tprotected Scir(Type type) => Type = type;'
		for name, members in types:
			generic = None
			if '<' in name:
				name, generic = name.split('<', 1)
				generic = [x.strip() for x in generic[:-1].split(',')]
			print >>fp
			members = [x.items()[0] for x in members]
			constraints = []
			for mname, mtype in members:
				if mname.startswith('where '):
					constraints.append(mname + ' : ' + mtype)
			members = [(mname, mtype) for (mname, mtype) in members if not mname.startswith('where ')]
			print >>fp, '\t\tpublic class %s%s : Scir%s {' % (name, '' if generic is None else '<%s>' % ', '.join(generic), '' if len(constraints) == 0 else ' ' + ' '.join(constraints))
			for mname, mtype in members:
				print >>fp, '\t\t\tpublic readonly %s %s;' % (mtype, mname)
			print >>fp
			print >>fp, '\t\t\tpublic %s(Type type%s) : base(type) {' % (name, (', ' + ', '.join('%s %s' % (mtype, mname[0].lower() + mname[1:]) for (mname, mtype) in members)) if len(members) else '')
			for mname, mtype in members:
				print >>fp, '\t\t\t\t%s = %s;' % (mname, mname[0].lower() + mname[1:])
			print >>fp, '\t\t\t}'
			if len(members):
				print >>fp
				print >>fp, '\t\t\tpublic void Deconstruct(%s) {' % ', '.join('out %s %s' % (mtype, mname[0].lower() + mname[1:]) for (mname, mtype) in members)
				for mname, mtype in members:
					print >>fp, '\t\t\t\t%s = %s;' % (mname[0].lower() + mname[1:], mname)
				print >>fp, '\t\t\t}'
			print >>fp
			print >>fp, '\t\t\tpublic override string ToString() => $"%s<{Type.ToPrettyString()}>(%s)";' % (name, ', '.join('%s={%s}' % (mname, mname) for (mname, _) in members))
			print >>fp, '\t\t}'
		print >>fp, '\t}'
		print >>fp, '}'

if __name__=='__main__':
	main()
