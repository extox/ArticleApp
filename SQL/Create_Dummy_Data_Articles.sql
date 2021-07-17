WITH name_list AS (
	SELECT '{"김승진", "장자미", "김선우", "김준우"}'::VARCHAR[] lname
)

INSERT INTO public."Articles"
SELECT 
	n, 
	lname[1 + mod(n, array_length(lname, 1))] || n as sname,
	lname[1 + mod(n, array_length(lname, 1))] || n || '입니다. 안녕하세요.',
	LOCALTIMESTAMP
FROM name_list, generate_series(11, 100000) as n